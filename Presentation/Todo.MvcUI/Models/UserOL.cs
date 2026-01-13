using System.ComponentModel.DataAnnotations;

namespace Todo.MvcUI.Models
{
    public class UserOL
    {
        public long Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [Required]
        public required MemberOL MemberInfo { get; set; }
    }
}
