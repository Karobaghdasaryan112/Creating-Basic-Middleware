namespace ustomLogger.Middlewere
{
    public class CustomMiddlewere
    {
        private RequestDelegate _next;
        private ILogger<CustomMiddlewere> _logger;
        public CustomMiddlewere(ILogger<CustomMiddlewere> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "GET")
            {
                await _next(context);
                return;
            }
            _logger.LogInformation("{Method} {Path}",context.Request.Method,context.Request.Path);
            await _next(context);
        }
    }
}
