using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TestCoreFramework.Base;
using TestCoreFramework.Config;
using TestProjectAutomationTests.Pages;

namespace TestProjectAutomationTests.Steps
{
    [Binding]
    internal class Main : BaseStep
    {

        private new readonly ParallelConfig _parallelConfig;

        public Main(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        #region Then

        [Then(@"I click on module button Tax Profiles")]
        public void ThenIClickOnButtonTaxProfiles()
        {
            _parallelConfig.CurrentPage= _parallelConfig.CurrentPage.As<PageMain>().ClickModuleTaxProfiles();   
        }

        #endregion

        #region And

        [Then(@"I check If website is open")]
        public void ThenICheckIfWebsiteIsOpen()
        {
            _parallelConfig.CurrentPage.As<PageMain>().AssertModuleMain();
        }

        #endregion

    }
}
