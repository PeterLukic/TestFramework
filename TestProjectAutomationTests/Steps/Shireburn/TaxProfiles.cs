using TechTalk.SpecFlow;
using TestCoreFramework.Base;
using TestProjectAutomationTests.Pages.Shireburn;

namespace TestProjectAutomationTests.Steps.Shireburn
{
    [Binding]
    internal class TaxProfiles : BaseStep
    {
        private new readonly ParallelConfig _parallelConfig;

        public TaxProfiles(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        #region Then
       
        [Then(@"I click on button Insert on page Tax Profiles")]
        public void ThenIClickOnButtonInsertOnPageTaxProfiles()
        {
            _parallelConfig.CurrentPage.As<PageTaxProfiles>().ClickButtonInsert();
        }

        [Then(@"I insert Tax profile with value ""([^""]*)""")]
        public void ThenIInsertTaxProfileWithValue(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxProfiles>().InsertTextBoxTaxProfile(value);
        }

        [Then(@"I insert Tax profile decription with value ""([^""]*)""")]
        public void ThenIInsertTaxProfileDecriptionWithValue(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxProfiles>().InsertTextBoxTaxProfileDescription(value);
        }

        [Then(@"I insert on search Tax profile value ""([^""]*)""")]
        public void ThenInsertOnSearchTaxProfileValue(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxProfiles>().InsertTextBoxSearchTaxProfile(value);
        }

        [Then(@"I select FSS Status with value ""([^""]*)""")]
        public void ThenISelectFSSStatusWithValue(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxProfiles>().ListBoxSelectFssStatus(value);
        }

        [Then(@"I click on checbox Tax on annual proj\. gross")]
        public void ThenIClickOnChecboxTaxOnAnnualProj_Gross()
        {
            _parallelConfig.CurrentPage.As<PageTaxProfiles>().ClickCheckBoxTaxOnAnnualProjGross();
        }

        [Then(@"I click on button Save on page Tax Profiles")]
        public void ThenIClickOnButtonSaveOnPageTaxProfiles()
        {
            _parallelConfig.CurrentPage.As<PageTaxProfiles>().ClickButtonSave();
        }

        [Then(@"I click on tab buton Rates")]
        public void ThenIClickOnTabButonRates()
        {
            _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<PageTaxProfiles>().ClickTabButtonRates();
        }

        [Then(@"I refesh page Tax Profiles")]
        public void ThenIRefeshPageTaxProfiles()
        {
            _parallelConfig.CurrentPage.As<PageTaxProfiles>().RefreshPage();
        }


        #endregion

        #region Asserts

        [Then(@"I check If Tax profile ""([^""]*)"" exist in table")]
        public void ThenICheckIfTaxProfileExistInTable(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxProfiles>().AssertTableTaxProfileRow1(value);
        }

        #endregion
    }
}
