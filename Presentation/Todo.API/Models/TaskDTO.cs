namespace Todo.API.Models
{
    public class TaskDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DueDate { get; set; }
        public long? AssignToMemberId { get; set; }
        public MemberDTO? AssignToMember { get; set; }
        public bool IsCompleted { get; set; }
    }
}
