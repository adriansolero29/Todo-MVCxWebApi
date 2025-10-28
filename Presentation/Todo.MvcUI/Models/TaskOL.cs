using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Todo.MvcUI.Models
{
    public class TaskOL
    {
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [DataType(DataType.Date)]
        [DefaultValue(null)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }
        public MemberOL? AssignedMember { get; set; }
        public List<SubTaskOL>? SubTasks { get; set; }
    }
}
