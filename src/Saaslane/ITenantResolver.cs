namespace Saaslane
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public interface ITenantResolver<TTenant>
    {
        Task<TenantContext<TTenant>> Resolve(HttpContext context);
    }
}