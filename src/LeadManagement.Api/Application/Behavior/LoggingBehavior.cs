using MediatR;

namespace LeadManagement.Api.Application.Behavior;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // Log the request details before passing it to the next behavior or handler
        _logger.LogInformation("Handling {RequestName} with data: {@Request}", typeof(TRequest).Name, request);

        var response = await next();

        // Log the response after the handler finishes
        _logger.LogInformation("Handled {RequestName} with response: {@Response}", typeof(TRequest).Name, response);

        return response;
    }
}