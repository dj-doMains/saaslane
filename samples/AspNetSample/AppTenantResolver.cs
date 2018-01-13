namespace AspNetSample
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Saaslane;

    public class AppTenantResolver : ITenantResolver
    {
        Task<TenantContext> ITenantResolver.Resolve(HttpContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}