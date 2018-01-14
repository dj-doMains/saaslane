namespace Saaslane.Internal
{
    using Microsoft.AspNetCore.Http;
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    public class SaaslaneMiddleware<TTenant>
    {
        private readonly RequestDelegate next;
        private readonly ILogger log;

        public SaaslaneMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.log = loggerFactory.CreateLogger<SaaslaneMiddleware<TTenant>>();
        }

        public async Task Invoke(HttpContext context, ITenantResolver<TTenant> tenantResolver)
        {
            log.LogDebug("Resolving TenantContext using {loggerType}.", tenantResolver.GetType().Name);

            var tenantContext = await tenantResolver.Resolve(context);

            if (tenantContext != null)
            {
                log.LogDebug("TenantContext Resolved. Adding to HttpContext.");
                context.SetTenantContext(tenantContext);
            }
            else
            {
                log.LogDebug("TenantContext Not Resolved.");
            }

            await next.Invoke(context);
        }
    }
}