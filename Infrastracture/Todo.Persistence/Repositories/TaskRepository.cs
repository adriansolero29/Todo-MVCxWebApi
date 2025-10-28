using Microsoft.EntityFrameworkCore;
using Todo.Entities;
using Todo.Interfaces.Repositories;
using Todo.Persistence.Data;
using Todo.Persistence.Entities;

namespace Todo.Persistence.Repositories;

public class TaskRepository : ITaskInfoRepository
{
    private readonly TodoDbContext dbContext;

    public TaskRepository(TodoDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<bool> DeleteAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteById(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TaskInfo>> GetAll()
    {
        try
        {
            var result = await dbContext.Tasks
                .Include(x => x.SubTasks)
                .Include(x => x.AssignedToMember)
                .ToListAsync();

            var output = result.Select(x => new TaskInfo(x.Name, x.DueDate)
            {
                Id = x.Id,
                AssignToMember = new Member(x.AssignedToMember?.First ?? "", x.AssignedToMember?.Last ?? ""),
                SubTaskList = x.SubTasks?.Select(i => new SubTaskInfo(x.Id, i.Name) { Id = i.Id }).ToList() ?? new List<SubTaskInfo>()
            });

            //.AddSubTask(x.SubTasks.Select(g => new SubTaskInfo(x.Id, g.Name)).ToList())

            return output;
        }
        catch (Exception ex)
        {
            throw new Exception("Error occured getting all task: " + ex.Message);
        }
    }

    public async Task<TaskInfo?> GetById(long id)
    {
        try
        {
            var result = await dbContext.Tasks.Include(x => x.AssignedToMember).FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }

            return new TaskInfo(result!.Name, result!.DueDate) { Id = result!.Id, AssignToMember = new Member(result!.AssignedToMember?.First ?? "", result!.AssignedToMember?.Last ?? "") };
        }
        catch (Exception ex)
        {

            throw new Exception("Error occured getting task: " + ex.Message);
        }
    }

    public async Task<bool> Insert(TaskInfo entity)
    {
        try
        {
            var toSave = new TaskInfoEntity()
            {
                Name = entity.Name,
                DueDate = entity.DueDate,
                AssignedToMemberId = entity.AssignedToMemberId
            };

            await dbContext.Tasks.AddAsync(toSave);
            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error occured inserting task: " + ex.Message);
        }
    }

    public async Task<bool> Update(TaskInfo entity)
    {
        try
        {
            if (entity?.Id == null) return false;

            var toUpdate = await dbContext.Tasks.FindAsync(entity.Id);
            if (toUpdate == null) return false;

            toUpdate.DueDate = entity.DueDate;
            toUpdate.AssignedToMemberId = entity.AssignedToMemberId;
            toUpdate.Name = entity.Name;
            toUpdate.IsCompleted = entity.IsCompleted;

            var subTasksFromEntity = entity.SubTasks.Select(x => new SubTaskInfoEntity() { Name = x.Name, IsCompleted = x.IsCompleted, TaskInfoId = x.TaskId });

            toUpdate.SubTasks?.AddRange(subTasksFromEntity);

            dbContext.Tasks.Update(toUpdate);
            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error occured inserting task: " + ex.Message);
        }
    }
}
