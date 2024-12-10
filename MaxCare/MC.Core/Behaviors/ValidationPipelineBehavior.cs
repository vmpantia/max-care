using FluentValidation;
using MC.Core.Extensions;
using MC.Shared.Results.Errors;
using MC.Shared.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MC.Core.Behaviors
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class
    {
        private readonly IServiceProvider _service;

        public ValidationPipelineBehavior(IServiceProvider service) => _service = service;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Skip pipeline once the request name is not ends with Command
            if (CommandExtension.IsNotCommand<TRequest>()) 
                return await next();

            // Get validator service based on the TRequest
            var validator = _service.GetRequiredService<IValidator<TRequest>>();

            // Check if the validator is not null
            if (validator != null)
                await validator.ValidateAndThrowAsync(request, cancellationToken);

            return await next();
        }
    }
}
