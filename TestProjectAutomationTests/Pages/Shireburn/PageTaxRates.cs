using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TestCoreFramework.Base;
using TestCoreFramework.Extensions;

namespace TestProjectAutomationTests.Pages.Shireburn
{
    class PageTaxRates : BasePage
    {
        public PageTaxRates(ParallelConfig parallelConfig) : base(parallelConfig) { }

        #region WebElements
        
        private IWebElement buttonInsert => _parallelConfig.Driver.FindByXpath("/html//div[@id='insertButton']");

        private IWebElement buttonSave => _parallelConfig.Driver.FindByXpath("/html//div[@id='saveButton']");

        private IWebElement buttonEdit => _parallelConfig.Driver.FindByXpath("/html//div[@id='editButton']");
        
        private IWebElement buttonDelete => _parallelConfig.Driver.FindByXpath("/html//div[@id='deleteActionButton']");

        private IWebElement textBoxSearchCode => _parallelConfig.Driver.FindByXpath("//body/div[1]/section[1]/div/section[@class='ListWrapper fxDisplay fxStretch']//section[@class='gridWrapper']//div[@role='grid']/div/div/div[4]/div[1]/div[2]/div/div[2]/input[@type='textarea']");

        private IWebElement textBoxCode => _parallelConfig.Driver.FindByXpath("//div[@role='gridcell']//input[@data-uid='TaxRate-Code']");

        private IWebElement dateTimeDateFrom => _parallelConfig.Driver.FindByXpath("//div[@role='textbox']//input[@data-uid='TaxRate-DateFrom']");

        private IWebElement dateTimeDateTo => _parallelConfig.Driver.FindByXpath("//div[@role='textbox']//input[@data-uid='TaxRate-DateTo']");

        private IWebElement numberEditorRangeFrom => _parallelConfig.Driver.FindByXpath("//input[@data-uid='TaxRate-RangeFrom']");
       
        private IWebElement numberEditorRangeTo => _parallelConfig.Driver.FindByXpath("//input[@data-uid='TaxRate-RangeTo']");

        private IWebElement numberEditorTaxRate => _parallelConfig.Driver.FindByXpath("//input[@data-uid='TaxRate-Rate']");

        private IWebElement numberEditorSubtract => _parallelConfig.Driver.FindByXpath("//input[@data-uid='TaxRate-Subtract']");
    
        private IWebElement checkBoxShowAsPt => _parallelConfig.Driver.FindByXpath("//div[@role='gridcell']//div[@data-uid='TaxRate-undefined']");

        private IWebElement toastContainerTitle => _parallelConfig.Driver.FindByXpath(" //div[@id='toast-container']//div[@class='toast-title']");

        private IWebElement toastContainerMessage => _parallelConfig.Driver.FindByXpath("//div[@id='toast-container']//div[@class='toast-message']");

        private IWebElement dialogbuttonDelete => _parallelConfig.Driver.FindByXpath("/html/body[@class='Layout isDesktop']//div[@role='dialog']//div[@class='ui-dialog-buttonset']/button[1]");

      
        #endregion

        #region Clicks

        public void ClickButtonInsert()
        {
            Thread.Sleep(1000);
            _parallelConfig.Driver.WaitElementToBeEnabled(TimeSpan.FromSeconds(60), buttonInsert);
            buttonInsert.Click();
            Thread.Sleep(1000);
        }

        public void ClickButtonSave()
        {
            buttonSave.Click();
            Thread.Sleep(2000);
        }

        public void ClickButtonEdit()
        {
            Thread.Sleep(1000);
            _parallelConfig.Driver.WaitElementToBeEnabled(TimeSpan.FromSeconds(60), buttonEdit);
            buttonEdit.Click();
        }

        public void ClickButtonDelete()
        {
            Thread.Sleep(1000);
            _parallelConfig.Driver.WaitElementToBeEnabled(TimeSpan.FromSeconds(60), buttonDelete);
            buttonDelete.Click();
        }

        public void ClickCheckBoxShowAsPt()
        {
            checkBoxShowAsPt.Click();
        }

        public void ClickDialogbuttonDelete()
        {
            dialogbuttonDelete.Click();
            Thread.Sleep(2000);
        }

        #endregion

        #region Inserts

        public void InsertTextBoxSearchCode(string textValue)
        {
            Thread.Sleep(1000);
            textBoxSearchCode.Click();
            textBoxSearchCode.SendKeys(textValue);
        }

        public void InsertTextBoxCode(string textValue)
        {
            Thread.Sleep(1000);
            _parallelConfig.Driver.WaitElementToBeEnabled(TimeSpan.FromSeconds(60), textBoxCode);
            textBoxCode.Clear();
            textBoxCode.SendKeys(textValue);
            textBoxCode.SendKeys(Keys.Tab);
        }

        public void InsertDateTimeDateFrom(string textValue)
        {
            textValue = textValue.Replace("/", string.Empty);
            Thread.Sleep(1000);
            dateTimeDateFrom.SendKeys(textValue);
            dateTimeDateFrom.SendKeys(Keys.Tab);
        }

        public void InsertDateTimeDateTo(string textValue)
        {
            textValue = textValue.Replace("/", string.Empty);
            Thread.Sleep(1000);
            dateTimeDateTo.SendKeys(textValue);
            dateTimeDateTo.SendKeys(Keys.Tab);
        }

        public void InsertNumberEditorRangeFrom(string textValue)
        {
            Thread.Sleep(1000);
            numberEditorRangeFrom.SendKeys(textValue);
            numberEditorRangeFrom.SendKeys(Keys.Tab);
        }

        public void InsertNumberEditorRangeTo(string textValue)
        {
            Thread.Sleep(1000);
            numberEditorRangeTo.SendKeys(textValue);
            numberEditorRangeTo.SendKeys(Keys.Tab);
          
        }

        public void InsertNumberEditorTaxRate(string textValue)
        {
            Thread.Sleep(1000);
            numberEditorTaxRate.SendKeys(textValue);
            numberEditorTaxRate.SendKeys(Keys.Tab);

        }

        public void InsertNumberEditorSubtract(string textValue)
        {
            Thread.Sleep(1000);
            numberEditorSubtract.SendKeys(textValue);
            //numberEditorSubtract.SendKeys(Keys.Tab);
        }

        public void InsertTextBoxTaxRates(string nameValue, string textValue)
        {
            switch (nameValue)
            {
                case "Code":
                    InsertTextBoxCode(textValue);
                    break;
                case "Date from":
                    InsertDateTimeDateFrom(textValue);
                    break;
                case "Date to":
                    InsertDateTimeDateTo(textValue);
                    break;
                case "Range from":
                    InsertNumberEditorRangeFrom(textValue);
                    break;
                case "Range to":
                    InsertNumberEditorRangeTo(textValue);
                    break;
                case "Tax rate":
                    InsertNumberEditorTaxRate(textValue);
                    break;
                case "Substract":
                    InsertNumberEditorSubtract(textValue);
                    break;
                default:
                    throw new NotImplementedException
                        ("Unrecognized value !!!");
            }

        }
        #endregion

        #region Asserts

        public void AssertToastContainerTitle(string textValue)
        {
            Assert.AreEqual(toastContainerTitle.Text, textValue);
        }

        public void AssertToastContainerMessage(string textValue)
        {
            Assert.AreEqual(toastContainerMessage.Text, textValue);
        }
        #endregion

        #region Methods

        public void SelectTaxRateFromGridWithIndex(string index)
        {
            _parallelConfig.Driver.FindByXpath("//html[1]/body[1]/div[1]/section[" + index + "]/div[1]/section[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[1]/div[4]/div[2]/div[1]/div[" + index + "]/div[1]/div[1]/div[1]/div[1]").Click();
            Thread.Sleep(2000);
        }

        #endregion
    }
}

