using TechTalk.SpecFlow;
using TestCoreFramework.Base;
using TestProjectAutomationTests.Pages.Shireburn;

namespace TestProjectAutomationTests.Steps.Shireburn
{
    [Binding]
    internal class TaxRates : BaseStep
    {
        private new readonly ParallelConfig _parallelConfig;

        public TaxRates(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        #region Then

        [Then(@"I click on button Insert on page Tax Rates")]
        public void ThenIClickOnButtonInsertOnPageTaxRates()
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().ClickButtonInsert();
        }

        [Then(@"I insert Code with values ""([^""]*)""")]
        public void ThenIInsertCodeWithValues(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().InsertTextBoxCode(value);
        }

        [Then(@"I insert Date from with value ""([^""]*)""")]
        [Then(@"I edit Date from with value ""([^""]*)""")]
        public void ThenIInsertDateFromWithValue(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().InsertDateTimeDateFrom(value);
        }

        [Then(@"I insert Date to with value ""([^""]*)""")]
        [Then(@"I edit Date to with value ""([^""]*)""")]
        public void ThenIInsertDateToWithValue(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().InsertDateTimeDateTo(value);
        }

        [Then(@"I insert Range from with value ""([^""]*)""")]
        [Then(@"I edit Range from with value ""([^""]*)""")]
        public void ThenIInsertRangeFromWithValue(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().InsertNumberEditorRangeFrom(value);
        }

        [Then(@"I insert Range to with value ""([^""]*)""")]
        [Then(@"I edit Range to with value ""([^""]*)""")]
        public void ThenIInsertRangeToWithValue(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().InsertNumberEditorRangeTo(value);
        }

        [Then(@"I insert Tax rate to with value ""([^""]*)""")]
        [Then(@"I edit Tax rate to with value ""([^""]*)""")]
        public void ThenIInsertTaxRateToWithValue(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().InsertNumberEditorTaxRate(value);
        }

        [Then(@"I insert Substract to with value ""([^""]*)""")]
        [Then(@"I edit Substract to with value ""([^""]*)""")]
        public void ThenIInsertSubstractToWithValue(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().InsertNumberEditorSubtract(value);
        }

        [Then(@"I click on checbox Show as PT")]
        public void ThenIClickOnChecboxShowAsPT()
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().ClickCheckBoxShowAsPt();
        }

        [Then(@"I click on button Save on page Tax Rate")]
        public void ThenIClickOnButtonSaveOnPageTaxRate()
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().ClickButtonSave();
        }

        [Then(@"I click on button Edit on page Tax Rates")]
        public void ThenIClickOnButtonEditOnPageTaxRates()
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().ClickButtonEdit();
        }

        [Then(@"I select Tax Rate from Grid with index ""([^""]*)""")]
        public void ThenISelectTaxRateFromGridWithIndex(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().SelectTaxRateFromGridWithIndex(value);
        }

        [Then(@"I click on button Delete on page Tax Rate")]
        public void ThenIClickOnButtonDeleteOnPageTaxRate()
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().ClickButtonDelete();
        }

        [Then(@"I click on button Delete from dialog on page Tax Rate")]
        public void ThenIClickOnButtonDeleteFromDialogOnPageTaxRate()
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().ClickDialogbuttonDelete();
        }

        [Then(@"I insert on search Tax rate value ""([^""]*)""")]
        public void ThenIInsertOnSearchTaxRateValue(string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().InsertTextBoxSearchCode(value);
        }


        [Then(@"I insert ""([^""]*)"" with values ""([^""]*)""")]
        [Then(@"I edit ""([^""]*)"" with values ""([^""]*)""")]
        public void ThenIInsertWithValues(string name, string value)
        {
            _parallelConfig.CurrentPage.As<PageTaxRates>().InsertTextBoxTaxRates(name, value);
        }


        #endregion
    }
}
