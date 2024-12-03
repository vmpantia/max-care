using MC.Shared.Contracts.Repositories;
using MC.Shared.Models.Enumerations;
using Microsoft.AspNetCore.Mvc;

namespace MC.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository) =>
            _memberRepository = memberRepository;

        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            // Get all the members from the database
            var result = await _memberRepository.GetMembersAsync();

            return Ok(result);
        }
    }
}
