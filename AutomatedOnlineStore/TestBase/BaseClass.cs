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
            Browser.InitBrowser("FireFox");  
            Browser.LaunchApplication("http://automationpractice.com/");
        }

        [TearDown]
        public void CloseApplication()
        {
           Browser.Driver.Quit();
        }

    }
}
