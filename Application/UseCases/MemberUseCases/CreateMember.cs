using Todo.Entities;
using Todo.Interfaces.Repositories;

namespace Todo.UseCases.MemberUseCases
{
    public class CreateMember
    {
        private readonly IMemberRepository memberRepository;

        public CreateMember(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public async Task ExecuteCreateMember(Member obj)
        {
            try
            {
                await memberRepository.Insert(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
