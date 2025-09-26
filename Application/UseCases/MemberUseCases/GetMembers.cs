using Todo.Interfaces.Repositories;

namespace Todo.UseCases.MemberUseCases;

public record GetAllMemberResult(long id, string name);

public class GetMembers
{
    private readonly IMemberRepository memberRepository;

    public GetMembers(IMemberRepository memberRepository)
    {
        this.memberRepository = memberRepository;
    }

    public async Task<IEnumerable<GetAllMemberResult>> ExecuteAllAsync()
    {
        var result = await memberRepository.GetAll();

        return result.Select(x =>
            new GetAllMemberResult(x.Id, $"{x.First} {x.Last}")
        );
    }
}
