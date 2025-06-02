using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildBlocks.Behaviors
{
    public class LogginBeahavior<TRequest, TResponse>(ILogger<LogginBeahavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[START] Handle request={Request} - Response= {Response} - RequestData= {RequestData}",
                typeof(TRequest).Name, typeof(TResponse).Name, request);

            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();

            var timerTaken = timer.Elapsed;

            if (timerTaken.Seconds > 3)
                logger.LogWarning("[PERFORMACE] The request {Request} took {timeTaken} seconds",
                    typeof(TRequest).Name, timerTaken.Seconds);

            logger.LogInformation("[END] Handle {Request} with {Response}",
              typeof(TRequest).Name, typeof(TResponse).Name);
            return response;
        }
    }
}
