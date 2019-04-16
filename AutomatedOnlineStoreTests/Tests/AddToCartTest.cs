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
            bool found = cartPage.IsItemPresentInCart("Printed Summer Dress");
            Assert.IsTrue(found, "Item not added in cart");

        }
        [Test]
        public void When_verify_user_can_search_an_item()
        {
            var login = new LoginPage(Browser.Driver);
            login.Login("meenakshi@gmail.com", "meenakshi");
            var cartPage = new CartPage(Browser.Driver);
            cartPage.SearchItem.SendKeys("dresses");
            cartPage.SubmitSearch.Submit();
            string actual = cartPage.SearchListHeading.Text;
            Assert.IsTrue(actual.ToLower().Contains("dresses"));
        }

        [Test]
        public void When_verify_item_can_be_deleted_from_cart()
        {
            var login = new LoginPage(Browser.Driver);
            login.Login("meenakshi@gmail.com", "meenakshi");
            var cartPage = new CartPage(Browser.Driver);
            if (cartPage.IsItemPresentInCart("Printed Dress"))
            {
                string items = cartPage.NoOfItemsInCart.Text;
                if (items.Equals("1 Product"))
                {
                    cartPage.DeleteItemFromCart("Printed Dress").Click();
                    Assert.AreEqual("Your shopping cart is empty.", cartPage.EmptyCartMessage.Text);
                }
                else
                {
                    cartPage.DeleteItemFromCart("Printed Dress").Click();
                    bool found = cartPage.IsItemPresentInCart("Printed Dress");
                    Assert.IsTrue(!found);
                }
            }
            else
            {
                Assert.Fail("Your shopping Cart is empty");
            }
        }
    }
}
