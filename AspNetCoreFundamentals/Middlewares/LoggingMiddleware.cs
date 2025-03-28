using System.Text;
using AspNetCoreFundamentals.Interfaces;

namespace AspNetCoreFundamentals.Middlewares;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;
    private readonly IFileHelper _fileHelper;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger, IFileHelper fileHelper)
    {
        _next = next;
        _logger = logger;
        _fileHelper = fileHelper;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;
        StringBuilder logMessage = new StringBuilder();
        logMessage.AppendLine("---------------------------------");
        logMessage.AppendLine($"Request Time: {DateTime.UtcNow}");
        logMessage.AppendLine($"Request Schema: {request.Scheme}");
        logMessage.AppendLine($"Request Host: {request.Host}");
        logMessage.AppendLine($"Request Path: {request.Path}");
        logMessage.AppendLine($"Request Query String: {request.QueryString}");
        logMessage.AppendLine($"Request Method: {request.Method}");

        _fileHelper.WriteToFile(logMessage.ToString());
        _logger.LogInformation(logMessage.ToString());

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}