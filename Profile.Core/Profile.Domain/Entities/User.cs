using Profile.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Entities
{
    public class User: BaseEntity
    {
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Role { get; set; } = "";

        private User() { }
        public User(string email, string passwordHash, string role)
        {
            this.Email = email;
            this.PasswordHash = passwordHash;
            this.Role = role;
        }
    }
}
