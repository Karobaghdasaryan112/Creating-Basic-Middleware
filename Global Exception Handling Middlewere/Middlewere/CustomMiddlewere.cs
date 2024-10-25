using System.Text.RegularExpressions;

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
            _logger.LogInformation("{Method} {Path}", context.Request.Method, context.Request.Path);
            try
            {
                await _next(context);
            }
            catch (ArgumentNullException ArgNullEx)
            {
                _logger.LogError(ArgNullEx.Message);
            }
            catch (NullReferenceException RefEx)
            {
                _logger.LogError(RefEx.Message);
            }
            catch(ArgumentException ArgEx)
            {
                _logger.LogError(ArgEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
