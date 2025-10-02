using Todo.Entities;
using Todo.Interfaces.Repositories;

namespace Todo.UseCases.TaskUseCases;

public class CreateTask
{
    private readonly ITaskInfoRepository taskInfoRepository;

    public CreateTask(ITaskInfoRepository taskInfoRepository)
    {
        this.taskInfoRepository = taskInfoRepository;
    }

    public async Task ExecuteAsync(string name, DateTime? dueDate = null, long? assignToMemberId = null)
    {
        try
        {
            var toSave = new TaskInfo(name, dueDate, assignToMemberId);
            await taskInfoRepository.Insert(toSave);
        }
        catch (Exception ex)
        {
            throw new Exception("Use case error" + ex.Message);
        }
    }
}
