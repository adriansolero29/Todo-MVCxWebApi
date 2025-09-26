namespace Todo.Entities;

public class SubTaskInfo : BaseEntity
{
    public SubTaskInfo(TaskInfo task, string Name)
    {
        this.Task = task;
        this.Name = Name;
    }

    public TaskInfo Task { get; set; }
    public string Name { get; set; }
}
