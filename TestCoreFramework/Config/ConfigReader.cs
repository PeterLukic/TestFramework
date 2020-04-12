using System.IO;
using Microsoft.Extensions.Configuration;

namespace TestCoreFramework.Config
{ 
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configurationRoot = builder.Build();

            Settings.Url = configurationRoot.GetSection("testSettings").Get<TestSettings>().Url;
            Settings.TestType = configurationRoot.GetSection("testSettings").Get<TestSettings>().TestType;
            Settings.IsLog = configurationRoot.GetSection("testSettings").Get<TestSettings>().IsLog;
            Settings.LogPath = configurationRoot.GetSection("testSettings").Get<TestSettings>().LogPath;
            Settings.AppConnectionString = configurationRoot.GetSection("testSettings").Get<TestSettings>().AUTConnectionString;
            Settings.BrowserType = configurationRoot.GetSection("testSettings").Get<TestSettings>().Browser;
        }
    }
}
