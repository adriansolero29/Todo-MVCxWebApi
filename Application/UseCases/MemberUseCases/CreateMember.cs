using Todo.Entities;
using Todo.Interfaces.Repositories;

namespace Todo.UseCases.MemberUseCases;

public class CreateMember
{
    private readonly IMemberRepository memberRepository;

    public CreateMember(IMemberRepository memberRepository)
    {
        this.memberRepository = memberRepository;
    }

    public async Task ExecuteAsync(string firstName, string lastName)
    {
        try
        {
            var toSave = new Member(firstName, lastName);
            await memberRepository.Insert(toSave);
        }
        catch (Exception ex)
        {
            throw new Exception("Use case error: " + ex.Message);
        }
    }
}
