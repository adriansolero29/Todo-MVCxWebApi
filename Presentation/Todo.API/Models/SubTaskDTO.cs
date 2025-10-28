namespace Todo.API.Models
{
    public class SubTaskDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long TaskId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
