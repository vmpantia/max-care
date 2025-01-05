using MC.Shared.Models.Dtos.Members;

namespace MC.Web.Contracts
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberDto>> GetMembersAsync();
    }
}