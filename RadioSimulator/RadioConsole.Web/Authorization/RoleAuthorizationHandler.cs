using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using RadioConsole.Web.Models;
using RadioConsole.Web.Database;

namespace RadioConsole.Web.Authorization
{
    public class RoleAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        private readonly RadioDBContext _dbContext;

        public RoleAuthorizationHandler(RadioDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var validRole = false;

            if(requirement.AllowedRoles == null || requirement.AllowedRoles.Any() == false)
            {
                validRole = true;
            }
            else
            {
                var claims = context.User.Claims;
                var username = claims.FirstOrDefault(x => x.Type == "Username").Value;
                var roles = requirement.AllowedRoles;

                validRole = _dbContext.Users.Where(x => roles.Contains(x.Role) && x.Username == username).Any();
            }

            if (validRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
