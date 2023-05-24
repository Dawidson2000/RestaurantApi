using System.Diagnostics;

namespace RestaurantApi.Middleware
{
    public class TimeRequestMiddleware : IMiddleware
    {
        private readonly Stopwatch _stopwatch;
        private readonly ILogger _logger;

        public TimeRequestMiddleware(Stopwatch stopwatch, ILogger<TimeRequestMiddleware> logger) 
        {
            _stopwatch = stopwatch;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Start();
            await next.Invoke(context);
            _stopwatch.Stop();

            var time = _stopwatch.ElapsedMilliseconds;

            if(time > 1000 * 4)
            {
                var message = $"Request: {context.Request.Method} at {context.Request.Path} took {time} miliseconds";
                _logger.LogInformation(message);
            }
        }
    }
}
