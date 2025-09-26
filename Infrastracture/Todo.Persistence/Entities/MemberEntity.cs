using System.ComponentModel.DataAnnotations;

namespace Todo.Persistence.Entities;

public class MemberEntity
{
    [Key]
    public long Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string First { get; set; }
    [Required]
    [StringLength(50)]
    public required string Last { get; set; }
}
