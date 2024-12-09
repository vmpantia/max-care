using MC.Shared.Results;
using MC.Shared.Results.Errors;
using MC.Shared.Results.Errors.Enumerations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MC.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator) =>
            _mediator = mediator;

        protected async virtual Task<IActionResult> SendRequestAsync<TData>(IRequest<Result<TData>> request)
            where TData : class
        {
            try
            {
                // Send a request to command or query
                var result = await _mediator.Send(request);

                // Check if the result is success
                if (result.IsSuccess) return Ok(result);

                return result.Error?.Type switch
                {
                    ErrorType.NotFound => NotFound(result),
                    _ => BadRequest(result)
                };
            }
            catch (Exception ex)
            {
                return BadRequest(CommonError.Exception(ex));
            }
        }
    }
}
