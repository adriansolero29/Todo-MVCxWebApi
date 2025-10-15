namespace Todo.MvcUI.Models
{
    public class SubTaskOL
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long TaskId { get; set; }
        public TaskOL? TaskInfo { get; set; }
        public bool IsCompleted { get; set; }
    }
}
