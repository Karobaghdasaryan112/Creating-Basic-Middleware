using System.Text;
using System.Text.Json;
using ustomLogger.Models;

namespace Multiple_Middlewares.Middlewere
{
    public class LoggingMiddlewere
    {
        private RequestDelegate _next;
        private ILogger<LoggingMiddlewere> _logger;
        public LoggingMiddlewere(RequestDelegate next, ILogger<LoggingMiddlewere> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "POST")
            {
                context.Request.EnableBuffering();
                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8))
                {
                    var body = await reader.ReadToEndAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // Игнорируем регистр имен
                    };

                    var user = JsonSerializer.Deserialize<User>(body, options);
                    context.Items["RequestUser"] = user;

                    Console.WriteLine(user.ToString());
                }
            }
            await _next(context);
        }
    }
    public static class ExtentionLoggingMiddlewere
    {
        public static IApplicationBuilder UseLoggingMiddlewere(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddlewere>();
        }
    }
}
