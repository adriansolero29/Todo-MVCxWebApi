using Microsoft.AspNetCore.Identity;
using Todo.Entities;
using Todo.Interfaces.Repositories;
using Todo.Persistence.Data;
using Todo.Persistence.Entities;

namespace Todo.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoDbContext dbContext;
        private readonly UserManager<UserEntity> userManager;

        public UserRepository(TodoDbContext dbContext, UserManager<UserEntity> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public Task<bool> DeleteAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserInfo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserInfo?> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insert(UserInfo entity)
        {
            var user = new UserEntity() { UserName = entity.Username };
            var result = await userManager.CreateAsync(user, entity.Password);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                throw new Exception("Error Saving User: " + string.Join(", ", result.Errors.Select(x => x.Description)));
            }
        }

        public Task<bool> Update(UserInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
