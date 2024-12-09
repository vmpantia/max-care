using MC.Core.Members.Commands;
using MC.Core.Members.Queries;
using MC.Shared.Models.Dtos.Members;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MC.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : BaseController
    {
        public MembersController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetMembersAsync() => await SendRequestAsync(new GetMembersQuery());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMembersAsync(Guid id) => await SendRequestAsync(new GetMemberByIdQuery(id));

        [HttpPost]
        public async Task<IActionResult> CreateMemberAsync([FromBody] CreateMemberDto dto) => await SendRequestAsync(new CreateMemberCommand(dto));
    }
}
