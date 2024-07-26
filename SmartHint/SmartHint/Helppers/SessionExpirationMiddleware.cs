using Microsoft.AspNetCore.Http;

namespace SmartHint.Helppers
{

    public class SessionExpirationMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionExpirationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
           await _next(context);
        }
    }
}
