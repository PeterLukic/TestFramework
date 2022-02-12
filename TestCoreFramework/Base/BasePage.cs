

namespace TestCoreFramework.Base
{

    public abstract class BasePage : Base
    {

        public BasePage(ParallelConfig parallelConfig) : base(parallelConfig) { }

        public void RefreshPage()
        {
            _parallelConfig.Driver.Navigate().Refresh();
        }
    }
}
