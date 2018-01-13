namespace Saaslane
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public interface ITenantResolver
    {
        Task<TenantContext> Resolve(HttpContext context);
    }
}