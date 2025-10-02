using Todo.Interfaces.Repositories;

namespace Todo.UseCases.TaskUseCases;

public record TaskMemberResult(string first, string last);
public record GetTasksResult(long id, string name, DateTime? dueDate, TaskMemberResult assignedMember);

public class GetTasks
{
    private readonly ITaskInfoRepository taskInfoRepository;

    public GetTasks(ITaskInfoRepository taskInfoRepository)
	{
        this.taskInfoRepository = taskInfoRepository;
    }

    public async Task<GetTasksResult?> ExecuteOneAsync(long id)
    {
        try
        {
            var result = await taskInfoRepository.GetById(id);
            if (result == null)
            {
                return null;
            }

            return new GetTasksResult(result!.Id, result?.Name ?? "", result?.DueDate, new TaskMemberResult(result?.AssignToMember?.First ?? "", result?.AssignToMember?.Last ?? ""));
        }
        catch (Exception ex)
        {
            throw new Exception("Error occured on get task use case: " + ex.Message);
        }
    }

    public async Task<IEnumerable<GetTasksResult>> ExecuteAllAsync()
    {
		try
		{
            var result = await taskInfoRepository.GetAll();
            return result.Select(x => 
                new GetTasksResult(
                    x.Id,
                    x.Name ?? "", 
                    x.DueDate, 
                    new TaskMemberResult(x.AssignToMember?.First ?? "", x.AssignToMember?.Last ?? "")));
		}
		catch (Exception ex)
		{
            throw new Exception("Error occured on get task use case: " + ex.Message);
		}
    }
}
