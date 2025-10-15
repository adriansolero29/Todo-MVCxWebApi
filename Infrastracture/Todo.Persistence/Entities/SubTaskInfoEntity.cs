using System.ComponentModel.DataAnnotations;

namespace Todo.Persistence.Entities;

public class SubTaskInfoEntity
{
    [Key]
    public long Id { get; set; }
    [Required]
    [StringLength(100)]
    public required string Name { get; set; }
    public long TaskInfoId { get; set; }
    public TaskInfoEntity? TaskInfo { get; set; }
    public bool IsCompleted { get; set; }
}
