namespace Microsoft.AspNetCore.Builder
{
    using Saaslane.Internal;

    public static class SaaslaneMiddlewareExtensions
    {
        public static IApplicationBuilder UseSaaslane<TTenant>(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SaaslaneMiddleware<TTenant>>();
        }
    }
}