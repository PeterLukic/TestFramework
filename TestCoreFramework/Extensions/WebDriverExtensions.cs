using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;

namespace TestCoreFramework.Extensions
{ 
    public static class WebDriverExtensions
    {
        public static IWebElement WaitElement(this IWebDriver driver, By by, int timeoutInSeconds)

        {

            if (timeoutInSeconds > 0)

            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

                return wait.Until(drv => drv.FindElement(by));

            }

            return driver.FindElement(by);

        }





        public static void WaitForPageLoadedJavaScript(this IWebDriver driver)

        {

            driver.WaitForCondition(dri =>

            {

                var state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();

                return state == "complete";

            }, 10);

        }

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

                    catch (Exception)

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


        public static void WaitElementToBeEnabled(this IWebDriver driver, TimeSpan waitTime, IWebElement element)
        {
            var wait = new WebDriverWait(driver, waitTime);
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }


        public static void WaitElement(this IWebDriver driver, IWebElement element, TimeSpan waitTime)
        {
            var wait = new WebDriverWait(driver, waitTime);
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
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

        public static IWebElement FindElementById(this RemoteWebDriver remoteWebDriver, string element)

        {

            try

            {

                if (remoteWebDriver.FindElementById(element).IsElementPresent())

                {

                    return remoteWebDriver.FindElementById(element);

                }

            }

            catch (Exception)

            {

                throw new ElementNotVisibleException($"Element not found : {element}");

            }

            return null;

        }



        public static void SwitchToFrame(this IWebDriver driver, IWebElement frame)

        {

            driver.SwitchTo().Frame(frame);

            driver.SwitchTo().DefaultContent();

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

            catch (Exception)

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

            catch (Exception)

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

            catch (Exception)

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

            catch (Exception)

            {

                throw new ElementNotVisibleException($"Element not found : {element}");

            }

            return null;

        }





    }
}
