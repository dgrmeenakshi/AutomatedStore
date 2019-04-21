using AutomatedOnlineStore.ElementExtensions;
using AutomatedOnlineStore.WrapperFactory;
using OpenQA.Selenium;

namespace AutomatedOnlineStore.PageObjects
{
    public class CartPage
    {
        private static IWebDriver _driver;
        private string mainMainBefore = "//div[@id='block_top_menu']//li/a[@title='";

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement AddToCart => _driver.FindElement(By.XPath("//p[@id='add_to_cart']/button/span"));

        public IWebElement AddToCartSuccessMessage =>
            _driver.FindElement(By.XPath("//span[@title='Close window']/following::h2"));

        public IWebElement SearchItem => _driver.FindElement(By.Id("search_query_top"));

        public IWebElement SubmitSearch => _driver.FindElement(By.Name("submit_search"));

        public IWebElement SearchListHeading => _driver.FindElement(By.XPath("//span[@class='lighter']"));

        public IWebElement NoOfItemsInCart => _driver.FindElement(By.XPath("//span[@id='summary_products_quantity']"));

        public IWebElement ProductListing => _driver.FindElement(By.XPath("//h1[@class='page-heading product-listing']/span"));
        public IWebElement EmptyCartMessage => _driver.FindElement(By.XPath("//p[@class='alert alert-warning']"));
        public IWebElement MainMenu(string primaryOption)
        {
            return _driver.FindElement(By.XPath(mainMainBefore + primaryOption + "']"));

        }
        public IWebElement SubMenu(string primaryOption, string secondaryOption)
        {
            var mainMain = MainMenu(primaryOption);
            mainMain.Hover(Browser.Driver);
            return _driver.FindElement(By.XPath(mainMainBefore + primaryOption + "']/following-sibling::ul//li/a[@title='" + secondaryOption + "']"));
        }

        public IWebElement SelectItem(string itemName)
        {
            return _driver.FindElement(By.XPath("//a[@class='product_img_link']//img[@title ='" + itemName + "']"));
        }

        public IWebElement DeleteItemFromCart(string itemName)
        {
            return _driver.FindElement(By.XPath("//a[contains(text(),'" + itemName +
                                                "')]//following::td[5]/div/a[@title='Delete']"));
        }

        public bool IsItemPresentInCart(string itemName)
        {

            string before = "//table[@id='cart_summary']/tbody/tr[";
            string after = "]/td[2]";
            var table = _driver.FindElement(By.XPath("//table[@id='cart_summary']/tbody"));
            var totalItemsCountInCart = table.FindElements(By.TagName("tr")).Count;
            bool found = false;
            for (int i = 1; i <= totalItemsCountInCart; i++)
            {
                string name = _driver.FindElement(By.XPath(before + i + after)).Text;
                string actualName = name.Substring(0, name.IndexOf('\r'));
                if (actualName.Equals(itemName))
                {
                    found = true;
                }
                else
                {
                    found = false;
                }

            }
            return found;
        }
    }

}



