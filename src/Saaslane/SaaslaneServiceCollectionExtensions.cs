namespace Microsoft.Extensions.DependencyInjection
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Saaslane;

    public static class MultitenancyServiceCollectionExtensions
    {
        public static IServiceCollection AddMultitenancy<TTenant, TResolver>(this IServiceCollection services)
            where TResolver : class, ITenantResolver<TTenant>
            where TTenant : class
        {
            services.AddScoped<ITenantResolver<TTenant>, TResolver>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Make Tenant and TenantContext injectable
            services.AddScoped(prov => prov.GetService<IHttpContextAccessor>()?.HttpContext?.GetTenantContext<TTenant>());
            services.AddScoped(prov => prov.GetService<TenantContext<TTenant>>()?.Tenant);

            // Make ITenant injectable for handling null injection, similar to IOptions
            services.AddScoped<ITenant<TTenant>>(prov => new TenantWrapper<TTenant>(prov.GetService<TTenant>()));

            // Ensure caching is available for caching resolvers
            var resolverType = typeof(TResolver);
            if (typeof(MemoryCacheTenantResolver<TTenant>).IsAssignableFrom(resolverType))
            {
                services.AddMemoryCache();
            }

            return services;
        }
    }
}