using Todo.Entities;
using Todo.Interfaces.Repositories;

namespace Todo.UseCases.TaskUseCases;

public class SetDueDate
{
    private readonly ITaskInfoRepository taskInfoRepository;

    public SetDueDate(ITaskInfoRepository taskInfoRepository)
    {
        this.taskInfoRepository = taskInfoRepository;
    }

    public async Task Execute(long taskId, DateTime dueDate)
    {
        var task = await taskInfoRepository.GetById(taskId);
        if (task == null) return;    

        task.SetDueDate(dueDate);

        await taskInfoRepository.Update(task);
    }
}
