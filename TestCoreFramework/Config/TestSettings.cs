using TestCoreFramework.Base;
using Newtonsoft.Json;

namespace TestCoreFramework.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("browser")]
        public BrowserType Browser { get; set; }

        [JsonProperty("testType")]
        public string TestType { get; set; }

        [JsonProperty("isLog")]
        public string IsLog { get; set; }

        [JsonProperty("logPath")]
        public string LogPath { get; set; }

        [JsonProperty("autConnectionString")]
        public string AUTConnectionString { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
