using Microsoft.EntityFrameworkCore;
using Todo.Entities;
using Todo.Interfaces.Repositories;
using Todo.Persistence.Data;
using Todo.Persistence.Entities;

namespace Todo.Persistence.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly TodoDbContext context;

    public MemberRepository(TodoDbContext context)
    {
        this.context = context;
    }

    public Task<bool> DeleteAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteById(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Member>> GetAll()
    {
        try
        {
            var result = await context.Members.ToListAsync();
            return result.Select(x => new Member(x.First, x.Last) { Id = x.Id });
        }
        catch (Exception ex)
        {
            throw new Exception("Exception occured while getting all data: " + ex.Message);
        }
    }

    public Task<Member?> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Insert(Member entity)
    {
        try
        {
            var memberEntityMap = new MemberEntity()
            {
                First = entity.First,
                Last = entity.Last
            };

            await context.Members.AddAsync(memberEntityMap);
            await context.SaveChangesAsync();

            return true;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Database update exception: " + ex.Message);
        }
    }

    public Task<bool> Update(Member entity)
    {
        throw new NotImplementedException();
    }
}
