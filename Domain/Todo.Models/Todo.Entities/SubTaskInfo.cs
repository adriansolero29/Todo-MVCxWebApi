namespace Todo.Entities;

public class SubTaskInfo : BaseEntity
{
    public SubTaskInfo(TaskInfo task, string Name)
    {
        this.Task = task;
        this.Name = Name;
    }

    public required TaskInfo Task { get; set; }
    public required string Name { get; set; }
}
