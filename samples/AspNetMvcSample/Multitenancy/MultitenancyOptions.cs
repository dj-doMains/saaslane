namespace AspNetMvcSample.Multitenancy
{
    using System.Collections.ObjectModel;

    public class MultitenancyOptions
    {
        public Collection<AppTenant> Tenants { get; set; }
    }
}
