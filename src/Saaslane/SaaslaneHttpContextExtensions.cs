namespace Microsoft.AspNetCore.Http
{
    using Saaslane;

    /// <summary>
    /// Extensions for <see cref="HttpContext"/>.
    /// </summary>
    public static class SaaslaneHttpContextExtensions
    {
        private const string TenantContextKey = "saaslane.TenantContext";

        public static void SetTenantContext<TTenant>(this HttpContext context, TenantContext<TTenant> tenantContext)
        {
            context.Items[TenantContextKey] = tenantContext;
        }

        public static TenantContext<TTenant> GetTenantContext<TTenant>(this HttpContext context)
        {
            object tenantContext;
            if (context.Items.TryGetValue(TenantContextKey, out tenantContext))
            {
                return tenantContext as TenantContext<TTenant>;
            }

            return null;
        }

        public static TTenant GetTenant<TTenant>(this HttpContext context)
        {
            var tenantContext = GetTenantContext<TTenant>(context);

            if (tenantContext != null)
            {
                return tenantContext.Tenant;
            }

            return default(TTenant);
        }
    }
}