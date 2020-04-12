using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestCoreFramework.Base
{
    public class ParallelConfig
    {
        public RemoteWebDriver Driver { get; set; }
        public BasePage CurrentPage { get; set; }
        public MediaEntityModelProvider CaptureScreenshotsAndReturnModel(string name)
        {
            var screenshots = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshots, name).Build();
        }

    }
}
