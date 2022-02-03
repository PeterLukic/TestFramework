﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;
using TestCoreFramework.Base;
using TestCoreFramework.Extensions;


namespace TestProjectAutomationTests.Pages
{
    class PageTaxProfiles : BasePage
    {
        public PageTaxProfiles(ParallelConfig parallelConfig) : base(parallelConfig) { }

        #region WebElements

        private IWebElement buttonInsert => _parallelConfig.Driver.FindByXpath("/html//div[@id='insertButton']");
        
        private IWebElement buttonSave => _parallelConfig.Driver.FindByXpath("/html//div[@id='saveButton']");
     
        private IWebElement textBoxTaxProfile => _parallelConfig.Driver.FindByXpath(" //div[@role='gridcell']//input[@data-uid='TaxProfile-Code']");

        private IWebElement textBoxTaxProfileDescription => _parallelConfig.Driver.FindByXpath("//div[@role='gridcell']//input[@data-uid='TaxProfile-Description']");
        
        private IWebElement listBoxFssStatus => _parallelConfig.Driver.FindByXpath("/html[1]/body[1]/div[1]/section[1]/div[1]/section[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]");

        private IWebElement checkBoxTaxOnAnnualProjGross => _parallelConfig.Driver.FindByXpath("//div[@role='gridcell']//div[@data-uid='TaxProfile-undefined']");

        private IWebElement tabButtonRates => _parallelConfig.Driver.FindById("taxratebutton");
        
        #endregion

        #region Clicks

        public void ClickButtonInsert()
        {
            _parallelConfig.Driver.WaitElementToBeEnabled(TimeSpan.FromSeconds(60), buttonInsert);
            buttonInsert.Click();
        }

        public void ClickButtonSave()
        {
            buttonSave.Click();
        }

        public void ClickCheckBoxTaxOnAnnualProjGross()
        {
            checkBoxTaxOnAnnualProjGross.Click();
            Thread.Sleep(2000);
        }

        public PageTaxRates ClickTabButtonRates()
        {
            Thread.Sleep(2000);
            _parallelConfig.Driver.WaitElementToBeEnabled(TimeSpan.FromSeconds(60), tabButtonRates);
            tabButtonRates.Click();
            _parallelConfig.Driver.WaitElement(By.XPath("//body/div[1]/section[1]/div/section[@class='ListWrapper fxDisplay fxStretch']//section[@class='gridWrapper']//div[@role='grid']/div/div/div[4]/div[1]/div[2]/div/div[3]/div[@role='textbox']//input[@type='textarea']"), 60);
            return new PageTaxRates(_parallelConfig);
        }

        #endregion

        #region Insert

        public void InsertTextBoxTaxProfile(string textValue)
        {
            Thread.Sleep(1000);
            _parallelConfig.Driver.WaitElementToBeEnabled(TimeSpan.FromSeconds(60), textBoxTaxProfile);
            textBoxTaxProfile.SendKeys(textValue);
            textBoxTaxProfile.SendKeys(Keys.Tab);
        }


        public void InsertTextBoxTaxProfileDescription(string textValue)
        {
            Thread.Sleep(1000);
            textBoxTaxProfileDescription.Click();
            textBoxTaxProfileDescription.SendKeys(textValue);
            textBoxTaxProfileDescription.SendKeys(Keys.Tab);

        }

        #endregion

        #region Methods 

        public void ListBoxSelectFssStatus(string listBoxValue)
        {
            Thread.Sleep(1000);
            listBoxFssStatus.Click();
            Thread.Sleep(1000);
            var listBoxFssStatusValues = listBoxFssStatus.FindElement(By.XPath("//div[@role='listbox']//span[contains(text(),'" + listBoxValue + "')]"));
            Thread.Sleep(1000);
            listBoxFssStatusValues.Click();            
        }

        #endregion


    }
}

   