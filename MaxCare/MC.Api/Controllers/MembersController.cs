using MC.Core.Members.Queries;
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
        public async Task<IActionResult> GetMembers()
        {
            var result = await _mediator.Send(new GetMembersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMembers(Guid id)
        {
            var result = await _mediator.Send(new GetMemberByIdQuery(id));
            return Ok(result);
        }
    }
}
