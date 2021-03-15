using Microsoft.Extensions.Configuration;

namespace CustomerOrder.Core.Settings
{
    public class Settings : ISettings
    {
        public string CustomerDetailApiUrl { get; set; }
        public string ApiKey { get; set; }
        public string DbConnectionString { get; set; }

        public Settings(IConfiguration configuration)
        {
            DbConnectionString = configuration.GetConnectionString("OrderDb");
            var section = configuration.GetSection("CustomerDetailApi");
            CustomerDetailApiUrl = section["Url"];
            ApiKey = section["ApiKey"];
        }
    }
}
