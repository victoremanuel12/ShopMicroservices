using BuildBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildBlocks.Behaviors
{
    public class ValidationBeahavior<TResquest, TResponse>(IEnumerable<IValidator<TResquest>> validators) : IPipelineBehavior<TResquest, TResponse>
        where TResquest : ICommand<TResponse>
    {
        public async Task<TResponse> Handle(TResquest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TResquest>(request);

            var validatorResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validatorResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Any())
                throw new ValidationException(failures);
            return await next();
        }
    }
}
