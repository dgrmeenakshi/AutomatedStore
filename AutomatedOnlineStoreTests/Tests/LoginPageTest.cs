using AutomatedOnlineStore.PageObjects;
using AutomatedOnlineStore.TestBase;
using AutomatedOnlineStore.WrapperFactory;
using NUnit.Framework;


namespace AutomatedOnlineStoreTests.Tests
{
    [TestFixture]
    public class LoginPageTest : BaseClass
    {
      [Test]
        //Login to application with InValid Credentials
        public void VerifyLoginWithInValidCredentials()
        {
            var login = new LoginPage(Browser.Driver);
            login.Login("meenakshi@gmail.com", "meenakshi");
            Assert.AreEqual(login.ErrorMessage(), "Authentication failed.","Login Failed");

        }
    }
}
