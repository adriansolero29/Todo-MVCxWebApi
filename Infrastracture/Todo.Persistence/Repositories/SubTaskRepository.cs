using Todo.Entities;
using Todo.Interfaces.Repositories;
using Todo.Persistence.Data;
using Todo.Persistence.Entities;

namespace Todo.Persistence.Repositories;

public class SubTaskRepository : ISubTaskInfoRepository
{
    private readonly TodoDbContext dbContext;

    public SubTaskRepository(TodoDbContext dbContext)
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

    public Task<IEnumerable<SubTaskInfo>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<SubTaskInfo?> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Insert(SubTaskInfo entity)
    {
        try
        {
            var toSave = new SubTaskInfoEntity()
            {
                Name = entity.Name,
                IsCompleted = entity.IsCompleted,
                TaskInfoId = entity.TaskId,
            };

            await dbContext.SubTasks.AddAsync(toSave);
            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error occured inserting subtask: " + ex.Message);
        }
    }

    public Task<bool> Update(SubTaskInfo entity)
    {
        throw new NotImplementedException();
    }
}
