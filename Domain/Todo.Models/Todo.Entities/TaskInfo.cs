namespace Todo.Entities;

public class TaskInfo : BaseEntity
{
    public TaskInfo(string? name, DateTime? dueDate = null, long? assignedToMemberId = null)
    {
        Name = name;
        DueDate = dueDate;
        AssignedToMemberId = assignedToMemberId;
    }

    public string? Name { get; set; }
    public DateTime? DueDate { get; private set; }
    public DateTime? DateCompleted { get; set; }
    public long? AssignedToMemberId { get; private set; }
    public Member? AssignToMember { get; set; }
    public bool IsCompleted { get; private set; } = false;

    private List<SubTaskInfo> subTasks = new();
    public IList<SubTaskInfo> SubTasks => subTasks.ToList();
    public List<SubTaskInfo>? SubTaskList { get; set; }

    public void AddSubTask(List<SubTaskInfo> subTaskList) => subTasks.AddRange(subTaskList);
    public void AddSubTask(SubTaskInfo subTask) => subTasks.Add(subTask);
    public void SetCompleted()
    {
        IsCompleted = true;
        DateCompleted = DateTime.Now;
    }

    public void SetDueDate(DateTime dueDate) => DueDate = dueDate;
    public void SetAssignee(long memberId) => AssignedToMemberId = memberId;
}
