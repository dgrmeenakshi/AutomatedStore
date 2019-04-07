using AutomatedOnlineStore.WrapperFactory;
using NUnit.Framework;


namespace AutomatedOnlineStore.TestBase
{
    [TestFixture]
   public class BaseClass
    {

        [SetUp]
        public void Init()
        {
            Browser.InitBrowser(Browser.BrowserType);  
            Browser.LaunchApplication();
        }

        [TearDown]
        public void CloseApplication()
        {
           Browser.Driver.Quit();
        }

    }
}
