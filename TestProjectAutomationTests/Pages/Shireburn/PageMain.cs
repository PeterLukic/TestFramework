using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TestCoreFramework.Base;
using TestCoreFramework.Extensions;
using TestProjectAutomationTests.Pages.Shireburn;

namespace TestProjectAutomationTests.Shireburn
{
    class PageMain : BasePage
    {
        public PageMain(ParallelConfig parallelConfig) : base(parallelConfig) { }

        #region WebElements

        private IWebElement moduleMain => _parallelConfig.Driver.FindByXpath("//div[@id='currentModule']/div[@class='currentModuleSection main']/header[@class='currentModuleSectionHeader']");

        private IWebElement moduleTaxProfiles => _parallelConfig.Driver.FindByXpath("//div[@id='currentModule']//a[@href='#/List/00103/QA01/HR/Payroll/TaxProfiles']/span[@class='currentModuleSectionGroup-moduleText fxStretch']");

        //div[@id='toast-container']//div[@class='toast-title']
        //div[@id='toast-container']//div[@class='toast-message']

        #endregion


        #region Clicks

        public PageTaxProfiles ClickModuleTaxProfiles()
        {
            _parallelConfig.Driver.WaitElementToBeEnabled(TimeSpan.FromSeconds(60), moduleTaxProfiles);
            Thread.Sleep(2000);
            moduleTaxProfiles.Click();
            _parallelConfig.Driver.WaitElement(By.XPath("/html//div[@id='taxprofilebutton']"), 60);
            return new PageTaxProfiles(_parallelConfig);
        }

        #endregion


        #region Asserts

        public void AssertModuleMain()
        {
            _parallelConfig.Driver.WaitElement(By.XPath("/html//input[@id='globalSearch']"), 60);
            Assert.AreEqual(true, moduleMain.Displayed);
        }

        #endregion
    }
}
