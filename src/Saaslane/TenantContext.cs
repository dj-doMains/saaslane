namespace Saaslane
{
    using System;

    public class TenantContext
    {

        public string Id { get; } = Guid.NewGuid().ToString();
    }
}