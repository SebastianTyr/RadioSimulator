using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioConsole.Web.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public IEnumerable<UsersModel> GetUsers()
        {
            return new List<UsersModel>()
            {
                new UsersModel
                {
                    Id = 1,
                    Username = "dyspozytor",
                    Password = "dyspozytor1",
                    Role = "Admin"
                },
                new UsersModel
                {
                    Id = 1,
                    Username = "operator",
                    Password = "operator1",
                    Role = "User"
                }
            };
        }
    }
}
