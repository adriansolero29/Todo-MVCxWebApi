using System.ComponentModel.DataAnnotations;

namespace Todo.MvcUI.ViewModels
{
    public class TaskDTO
    {
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
