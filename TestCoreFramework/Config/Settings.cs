using TestCoreFramework.Base;

namespace TestCoreFramework.Config
{
    public class Settings
    {
        public static string  TestType { get; set; }
        public static string Url { get; set; }
        public static BrowserType BrowserType { get; set; }
        public static string AppConnectionString { get; set; }
        public static string IsLog { get; set; }
        public static string LogPath { get; set; }
    }
}
