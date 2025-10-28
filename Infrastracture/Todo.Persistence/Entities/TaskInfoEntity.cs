using System.ComponentModel.DataAnnotations;

namespace Todo.Persistence.Entities;

public class TaskInfoEntity
{
    [Key]
    public long Id { get; set; }
    [Required]
    [StringLength(100)]
    public required string? Name { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? DateCompleted { get; set; }
    public long? AssignedToMemberId { get; set; }
    public MemberEntity? AssignedToMember { get; set; }
    public bool IsCompleted { get; set; } = false;
    public List<SubTaskInfoEntity>? SubTasks { get; set; } = new List<SubTaskInfoEntity>();
}
