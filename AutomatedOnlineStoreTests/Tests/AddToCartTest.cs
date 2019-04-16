using AutomatedOnlineStore.PageObjects;
using AutomatedOnlineStore.TestBase;
using AutomatedOnlineStore.WrapperFactory;
using NUnit.Framework;


namespace AutomatedOnlineStoreTests.Tests
{
    [TestFixture]
    public class AddToCartTest : BaseClass
    {
        [Test]
        public void When_verify_user_can_add_item_to_cart()
        {
            var login = new LoginPage(Browser.Driver);
            login.Login("meenakshi@gmail.com", "meenakshi");
            var cartPage = new CartPage(Browser.Driver);
            cartPage.MainMenu("Women").Click();
            cartPage.SelectItem("Printed Summer Dress").Click();
            cartPage.AddToCart.Submit();
            string actual = cartPage.AddToCartSuccessMessage.Text;
            Assert.IsTrue(actual.Contains("Product successfully added to your shopping cart"));
        }


    }
}
