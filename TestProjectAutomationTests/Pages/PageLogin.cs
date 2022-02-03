using OpenQA.Selenium;
using TestCoreFramework.Base;
using TestCoreFramework.Extensions;

namespace TestProjectAutomationTests.Pages
{
    class PageLogin : BasePage       
    {
        public PageLogin(ParallelConfig parallelConfig) : base(parallelConfig) { }

        #region WebElements

        private IWebElement textBoxUsername => _parallelConfig.Driver.FindByXpath("/html//input[@id='txtUsername']");

        private IWebElement textBoxPassword => _parallelConfig.Driver.FindByXpath("/html//input[@id='txtPassword']");

        private IWebElement buttonLogin => _parallelConfig.Driver.FindByXpath("/html//input[@id='submit']");

        #endregion

        #region Methods

        public PageMain Login(string userName, string password)
        {
            textBoxUsername.SendKeys(userName);
            textBoxPassword.SendKeys(password);
            buttonLogin.Click();
            return new PageMain(_parallelConfig);
        }

        #endregion
    }
}
