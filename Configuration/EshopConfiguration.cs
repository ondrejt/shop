using dotenv.net;

namespace PrestashopTesena.Configuration
{
    public static class EshopConfiguration
    {
        public static string DomainUrl { get; }
        static EshopConfiguration()
        {
            DotEnv.Load();
            DomainUrl = Environment.GetEnvironmentVariable("DOMAIN_URL") ?? "https://tesena.com";
        }
    }
}