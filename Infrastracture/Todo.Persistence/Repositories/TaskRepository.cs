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

    public Task<bool> DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TaskInfo>> GetAll()
    {
        try
        {
            var result = await dbContext.Tasks.Include(x => x.AssignedToMember).ToListAsync();
            return result
                .Select(x => new TaskInfo(x.Name, x.DueDate) { Id = x.Id, AssignToMember = new Member(x.AssignedToMember?.First ?? "", x.AssignedToMember?.Last ?? "") });
        }
        catch (Exception ex)
        {
            throw new Exception("Error occured getting all task: " + ex.Message);
        }
    }

    public Task<TaskInfo> GetById(int id)
    {
        throw new NotImplementedException();
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

    public Task<bool> Update(TaskInfo entity)
    {
        throw new NotImplementedException();
    }
}
