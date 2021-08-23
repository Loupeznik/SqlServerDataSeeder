using Microsoft.Extensions.Configuration;

namespace SqlServerDataSeeder.Data
{
    public class DbConnectionHelper
    {
        private static readonly IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddUserSecrets<Program>()
            .Build();

        public string GetConnectionString()
        {
            return Configuration.GetConnectionString("master");
        }
    }
}
