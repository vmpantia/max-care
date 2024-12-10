using Azure.Core;
using FluentValidation;
using MC.Core.Extensions;
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

        protected async virtual Task<IActionResult> SendRequestAsync<TRequest>(IRequest<Result<TRequest, Error>> request)
            where TRequest : class
        {
            try
            {
                // Send a request to command or query
                var result = await _mediator.Send(request);

                return result switch
                {
                    { IsSuccess: false, Error: var error } when error!.Type == ErrorType.NotFound => NotFound(result),
                    { IsSuccess: false } => BadRequest(result),
                    _ => Ok(result)
                };
            }
            catch (ValidationException ex)
            {
                return BadRequest((Result<TRequest, Error>)CommonError.Validation(ex.Errors.ToDictionary()));
            }
            catch (Exception ex)
            {
                return BadRequest((Result<TRequest, Error>)CommonError.Unexpected(ex));
            }
        }
    }
}
