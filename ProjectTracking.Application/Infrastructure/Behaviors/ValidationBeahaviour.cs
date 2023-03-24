using FluentValidation;
using MediatR;

namespace ProjectTracking.Application.Infrastructure.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failure = _validators.Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();
            if (failure.Count != 0)
            {
                throw new ValidationException(failure);
            }
            return next();
        }
    }
}
