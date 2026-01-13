using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Entities
{
    public class UserInfo : BaseEntity
    {
        public UserInfo(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public long MemberId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
