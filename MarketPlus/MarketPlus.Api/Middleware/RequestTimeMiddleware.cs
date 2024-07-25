using System.Diagnostics;

namespace MarketPlus.Api.Middleware
{
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimeMiddleware> _logger;
        public RequestTimeMiddleware(RequestDelegate next, ILogger<RequestTimeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();

            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Request [{context.Request.Method}] at [{context.Request.Path}] took {elapsedMilliseconds} ms.");
            var logMessage = $"[{DateTime.Now}] {context.Request.Method} {context.Request.Path} responded in {stopwatch.ElapsedMilliseconds} ms";

            await LogRequestTimeAsync(logMessage);
        }
        private async Task LogRequestTimeAsync(string logMessage)
        {
            var logFilePath = "request_time_log.txt";
            await File.AppendAllTextAsync(logFilePath, logMessage + Environment.NewLine);
        }
    }
}
