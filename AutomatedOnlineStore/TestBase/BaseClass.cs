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
            Browser.InitBrowser();
           
        }

        [TearDown]
        public void CloseApplication()
        {
            Browser.Close();
        }

    }
}
