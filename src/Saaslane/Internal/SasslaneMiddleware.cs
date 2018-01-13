namespace Saaslane.Internal
{
    using Microsoft.AspNetCore.Http;
    using System.Globalization;
    using System.Threading.Tasks;

    public class SaaslaneMiddleware
    {
        private readonly RequestDelegate _next;

        public SaaslaneMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            return this._next(context);
        }
    }
}