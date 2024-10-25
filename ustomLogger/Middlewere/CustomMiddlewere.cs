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
            _logger.LogInformation("{Method} {Path} {DateTime}",context.Request.Method, context.Request.Path,DateTime.UtcNow);
            await _next(context);
        }
    }
}
