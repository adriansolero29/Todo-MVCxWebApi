namespace Todo.Entities;

public class TaskInfo : BaseEntity
{
    public TaskInfo(string? name, DateTime? dueDate = null, Member? assignedToMember = null)
    {
        Name = name;
        DueDate = dueDate;
        AssignedToMember = assignedToMember;
    }

    public string? Name { get; set; }
    public DateTime? DueDate { get; private set; }
    public Member? AssignedToMember { get; private set; }
    public bool IsCompleted { get; private set; } = false;

    private List<SubTaskInfo> subTasks = new();
    public IReadOnlyList<SubTaskInfo> SubTasks => subTasks.ToList();

    public void SetCompleted() => IsCompleted = true;
    public void SetDueDate(DateTime dueDate) => DueDate = dueDate;
    public void SetAssignee(Member member) => AssignedToMember = member;
}
