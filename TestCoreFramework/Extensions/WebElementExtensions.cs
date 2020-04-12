﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCoreFramework.Extensions
{
    public static class WebElementExtensions
    {
        public static string GetSelectedDropDown(this IWebElement element)
        {
            var ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }
        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            var ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }
        public static string GetLinkText(this IWebElement element)
        {
            return element.Text;
        }
        public static void SelectDropDownList(this IWebElement element, string value)
        {
            var ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }
        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(string.Format("Element Not Present exception"));
        }
        public static bool IsElementPresent(this IWebElement element)
        {
            try
            {
                var ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
