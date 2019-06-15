using System;
namespace OrderService
{
    public class IdentityServerConfig
    {
        public string ServerIP { get; set; }
        public string ServerPort { get; set; }
        public string IdentityScheme { get; set; }
        public string ResourceName { get; set; }
    }
}
