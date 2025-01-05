using MC.Shared.Models.Dtos.Members;
using MC.Web.Contracts;

namespace MC.Web.Services
{
    public class MemberService : IMemberService
    {
        private readonly IApiService _api;

        public MemberService(IApiService api) => _api = api;

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            var members = await _api.GetAsync<IEnumerable<MemberDto>>("https://localhost:7043/Members");

            return members;
        }
    }
}
