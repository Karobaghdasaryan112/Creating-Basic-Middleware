namespace Multiple_Middlewares.Middlewere
{
    public class LoggingMiddlewereWithGet
    {
        private RequestDelegate _next;
        private ILogger<LoggingMiddlewereWithGet> _logger;
        public LoggingMiddlewereWithGet(RequestDelegate next, ILogger<LoggingMiddlewereWithGet> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Method == "GET")
            {
                var QuaryParams = httpContext.Request.Query as IQueryCollection;
                foreach (var kv in QuaryParams)
                {

                    Console.WriteLine(kv.Value);
                }
            }
            await _next(httpContext);
        }
    }
    public static class StaticClassForExtentionMiddlewere
    {
        public static IApplicationBuilder UseLoggingMiddlewereGet(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggingMiddlewereWithGet>();
        }
    }
}
