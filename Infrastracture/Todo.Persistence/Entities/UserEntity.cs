using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Persistence.Entities
{
    public class UserEntity : IdentityUser
    {
        public long? MemberId { get; set; }
        public MemberEntity? Member { get; set; }
    }
}
