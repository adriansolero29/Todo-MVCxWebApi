using Todo.Entities;
using Todo.Interfaces.Repositories;

namespace Todo.UseCases.UserUseCases
{
    public class CreateUser
    {
        private readonly IUserRepository userRepository;

        public CreateUser(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task ExecuteAsync(string username, string password)
        {
            try
            {
                var toSave = new UserInfo(username, password);
                await userRepository.Insert(toSave);
            }
            catch (Exception ex)
            {
                throw new Exception("Use case error" + ex.Message);
            }
        }
    }
}
