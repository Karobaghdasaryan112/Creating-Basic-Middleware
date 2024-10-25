namespace ustomLogger.Middlewere
{
    public class CustomMiddlewere
    {
        private RequestDelegate _next;
        private ILogger<CustomMiddlewere> _logger;
        public CustomMiddlewere(RequestDelegate next, ILogger<CustomMiddlewere> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers["X-Custom-Header"] = "CustomMiddleware-Test";
            _logger.LogInformation("{Header}", context.Response.Headers["X-Custom-Header"].ToString());
            await _next(context);
        }
    }
}
