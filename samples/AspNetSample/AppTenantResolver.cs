namespace AspNetSample
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Saaslane;

    public class AppTenantResolver : ITenantResolver<AppTenant>
    {
        Task<TenantContext<AppTenant>> ITenantResolver<AppTenant>.Resolve(HttpContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}