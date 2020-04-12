using TestCoreFramework.Config;
using TestCoreFramework.Helpers;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

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
        private void OpenBrowser(DriverOptions driverOptions)
        {
            switch (driverOptions)
            {
                case InternetExplorerOptions internetExplorerOptions:
                    //ToDo: Set the Desired capabilities
                    driverOptions = new InternetExplorerOptions();
                    break;
                case FirefoxOptions firefoxOptions:
                    firefoxOptions.AddAdditionalCapability(CapabilityType.BrowserName, "firefox");
                    firefoxOptions.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    firefoxOptions.BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    break;
                case ChromeOptions chromeOptions:
                    chromeOptions.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);
                    _parallelConfig.Driver = new ChromeDriver();
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
