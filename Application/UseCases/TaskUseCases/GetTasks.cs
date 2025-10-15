using Todo.Interfaces.Repositories;

namespace Todo.UseCases.TaskUseCases;

public record TaskMemberResult(long id, string first, string last);
public record SubTaskResult(long id, string name);
public record GetTasksResult(long id, string name, DateTime? dueDate, TaskMemberResult? assignedMember = null, List<SubTaskResult>? subtasks = null);

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

            return new GetTasksResult(result!.Id, result?.Name ?? "", result?.DueDate, new TaskMemberResult(result?.AssignToMember?.Id?? 0, result?.AssignToMember?.First ?? "", result?.AssignToMember?.Last ?? ""));
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
            var output = 
                result.Select(x => 
                new GetTasksResult(
                    x.Id,
                    x.Name ?? "", 
                    x.DueDate, 
                    new TaskMemberResult(x.AssignToMember?.Id ?? 0, x.AssignToMember?.First ?? "", x.AssignToMember?.Last ?? ""),
                    new List<SubTaskResult>(x.SubTaskList.Select(i => new SubTaskResult(i.Id, i.Name)).ToList())));
            return output;
		}
		catch (Exception ex)
		{
            throw new Exception("Error occured on get task use case: " + ex.Message);
		}
    }
}
