using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace RadioConsole.Web.Authorization
{
    public class CustomUserRequireClaim : IAuthorizationRequirement
    {
        public string ClaimType { get; }

        public CustomUserRequireClaim(string claimType)
        {
            ClaimType = claimType;
        }
    }
}
