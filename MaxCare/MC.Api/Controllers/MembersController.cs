using MC.Core.Members.Commands;
using MC.Core.Members.Queries;
using MC.Shared.Models.Dtos.Members;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MC.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembersController(IMediator mediator) =>
            _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetMembersAsync()
        {
            var result = await _mediator.Send(new GetMembersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMembersAsync(Guid id)
        {
            var result = await _mediator.Send(new GetMemberByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMemberAsync([FromBody] CreateMemberDto dto)
        {
            var result = await _mediator.Send(new CreateMemberCommand(dto));
            return Ok(result);
        }
    }
}
