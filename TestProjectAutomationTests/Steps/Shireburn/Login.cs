using TechTalk.SpecFlow;
using TestCoreFramework.Base;
using TestCoreFramework.Config;
using TestProjectAutomationTests.Pages.Shireburn;

namespace TestProjectAutomationTests.Steps.Shireburn
{
    [Binding]
    internal class Login : BaseStep
    {
        private new readonly ParallelConfig _parallelConfig;

        public Login(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        #region Given
        
        [Given(@"I open shireburn website")]
        public void GivenIOpenShireburnWebsite()
        {
            _parallelConfig.Driver.Navigate().GoToUrl(Settings.Url);
            _parallelConfig.CurrentPage = new PageLogin(_parallelConfig);
        }

        #endregion

        #region Then

        [Then(@"I login to website")]
        public void ThenILoginToWebsite()
        {
            _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<PageLogin>().Login(Settings.UserName, Settings.Password);
        }

        #endregion

    }
}
