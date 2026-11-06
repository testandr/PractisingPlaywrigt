using Microsoft.Extensions.Configuration;


namespace PracticingPlaywright.src.Configuration
{
    public static class ConfigurationLoader
    {
        public static AppConfig Load()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("src/Configuration/appsettings.json", optional: false)
                .Build()
                .Get<AppConfig>()
                ?? throw new InvalidOperationException(
                    "Failed to load configuration."
                );
        }
    }
}