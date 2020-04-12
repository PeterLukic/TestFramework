using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;

namespace TestCoreFramework.Extensions
{ 
    public static class WebDriverExtensions
    {
        //public static void WaitForPageLoaded(this IWebDriver driver)
        //{
        //    driver.WaitForCondition(dri =>
        //    {
        //        var state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();
        //        return state == "complete";
        //    }, 10);
        //}
        public static bool IsPopupPresent(this IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        public static void ClickOkOnPopup(this IWebDriver driver)
        {
            if (!IsPopupPresent(driver))
                return;
            driver.SwitchTo().Alert().Accept();
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        public static bool WaitForPageLoaded(this IWebDriver driver, TimeSpan waitTime)
        {
            WaitForDocumentReady(driver, waitTime);
            var ajaxReady = WaitForAjaxReady(driver, waitTime);
            WaitForDocumentReady(driver, waitTime);
            return ajaxReady;
        }

        private static void WaitForDocumentReady(IWebDriver driver, TimeSpan waitTime)
        {
            var wait = new WebDriverWait(driver, waitTime);
            var javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");

            wait.Until((d) =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript(
                        "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        private static bool WaitForAjaxReady(IWebDriver driver, TimeSpan waitTime)
        {
            System.Threading.Thread.Sleep(1000);
            var wait = new WebDriverWait(driver, waitTime);
            return wait.Until<bool>((d) => driver.FindElements(By.CssSelector(".waiting, .tb-loading")).Count == 0);
        }
        public static IWebElement FindById(this RemoteWebDriver remoteWebDriver, string element)
        {
            try
            {
                if (remoteWebDriver.FindElementById(element).IsElementPresent())
                {
                    return remoteWebDriver.FindElementById(element);
                }
            }
            catch (Exception e)
            {
                throw new ElementNotVisibleException($"Element not found : {element}");
            }
            return null;
        }

        public static IWebElement FindByXpath(this RemoteWebDriver remoteWebDriver, string element)
        {
            try
            {
                if (remoteWebDriver.FindElementByXPath(element).IsElementPresent())
                {
                    return remoteWebDriver.FindElementByXPath(element);
                }
            }
            catch (Exception e)
            {
                throw new ElementNotVisibleException($"Element not found : {element}");
            }
            return null;
        }

        public static IWebElement FindByCss(this RemoteWebDriver remoteWebDriver, string element)
        {
            try
            {
                if (remoteWebDriver.FindElementByCssSelector(element).IsElementPresent())
                {
                    return remoteWebDriver.FindElementByCssSelector(element);
                }
            }
            catch (Exception e)
            {
                throw new ElementNotVisibleException($"Element not found : {element}");
            }
            return null;
        }

        public static IWebElement FindByLinkText(this RemoteWebDriver remoteWebDriver, string element)
        {
            try
            {
                if (remoteWebDriver.FindElementByLinkText(element).IsElementPresent())
                {
                    return remoteWebDriver.FindElementByLinkText(element);
                }
            }
            catch (Exception e)
            {
                throw new ElementNotVisibleException($"Element not found : {element}");
            }
            return null;
        }

    }
}
