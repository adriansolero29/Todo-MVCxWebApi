namespace Todo.Entities;

public class SubTaskInfo : BaseEntity
{
    public SubTaskInfo(long taskId, string Name)
    {
        this.TaskId = taskId;
        this.Name = Name;
    }

    public long TaskId { get; set; }
    public string Name { get; set; }
}
