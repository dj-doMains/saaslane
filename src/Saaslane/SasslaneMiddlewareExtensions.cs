namespace Saaslane
{
    using Microsoft.AspNetCore.Builder;
    using Saaslane.Internal;

    public static class SaaslaneMiddlewareExtensions
    {
        public static IApplicationBuilder UseSaaslane(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SaaslaneMiddleware>();
        }
    }    
}