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
        public string Name { get; set; }
        public string Email { get; set; }
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
                    Name = "Jan",
                    Email = "jan.kowalski@test.com",
                    Password = "dyspozytor1",
                    Role = "Admin"
                },
                new UsersModel
                {
                    Id = 2,
                    Username = "operator",
                    Name = "Marek",
                    Email = "marek.kowalski@test.com",
                    Password = "operator1",
                    Role = "User"
                }
            };
        }
    }
}
