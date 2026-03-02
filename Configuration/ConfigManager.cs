using Microsoft.Extensions.Configuration;
using System.IO;

namespace QaAutomationPortfolio.Configuration
{
    public static class ConfigManager
    {
        private static IConfigurationRoot _configuration;

        static ConfigManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            _configuration = builder.Build();
        }

        public static string BaseUrl =>
            _configuration["TestSettings:BaseUrl"]!;

        public static bool Headless =>
            bool.Parse(_configuration["TestSettings:Headless"]!);
    }
}