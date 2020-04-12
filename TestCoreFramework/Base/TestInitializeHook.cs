using System;
using System.IO;
using System.Reflection;
using TestCoreFramework.Config;
using TestCoreFramework.Helpers;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace TestCoreFramework.Base
{ public class TestInitializeHook : Steps
    {
        private readonly ParallelConfig _parallelConfig;
        public TestInitializeHook(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }
        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();
            //Set Log
            LogHelpers.CreateLogFile();
            //Open Browser
            OpenBrowser(GetBrowserOption(Settings.BrowserType));
            //LogHelpers.Write("Initialized framework");
        }

        private static string GetDriversDirectoryPath()
        {
            var assemblyUri = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            return Path.Combine(Path.GetDirectoryName(assemblyUri), "WebDrivers");
        }
        private void OpenBrowser(DriverOptions driverOptions)
        {
            switch (driverOptions)
            {
                case InternetExplorerOptions internetExplorerOptions:
                    //ToDo: Set the Desired capabilities
                    var options = new InternetExplorerOptions();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    _parallelConfig.Driver = new InternetExplorerDriver(GetDriversDirectoryPath(), options);
                    _parallelConfig.Driver.Manage().Window.Maximize();
                    break;
                case FirefoxOptions firefoxOptions:
                    var ffOptions = new FirefoxOptions();
                    ffOptions.AddArgument("--no-sandbox");
                    ffOptions.SetPreference("capability.policy.default.Window.frameElement.get", "allAccess");
                    _parallelConfig.Driver = new FirefoxDriver(GetDriversDirectoryPath(), ffOptions, TimeSpan.FromMinutes(3));
                    _parallelConfig.Driver.Manage().Window.Maximize();
                    break;
                case ChromeOptions chromeOptions:
                    chromeOptions.AddArgument("start-maximized");
                    chromeOptions.AddArgument("--no-sandbox");
                    _parallelConfig.Driver = new ChromeDriver(GetDriversDirectoryPath(), chromeOptions, TimeSpan.FromMinutes(3));
                    break;
                case EdgeOptions edgeOptions:
                    edgeOptions.AddExtensionPath(GetDriversDirectoryPath());
                    _parallelConfig.Driver = new EdgeDriver(GetDriversDirectoryPath());
                    _parallelConfig.Driver.Manage().Window.Maximize();
                    break;
            }
        }
        public DriverOptions GetBrowserOption(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    return new InternetExplorerOptions();
                case BrowserType.FireFox:
                    return new FirefoxOptions();
                case BrowserType.Chrome:
                    return new ChromeOptions();
                default:
                    return new ChromeOptions();
            }
        }
    }
}
