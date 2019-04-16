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

        public IWebElement MainMenu(string primaryOption)
        {
            return _driver.FindElement(By.XPath(mainMainBefore + primaryOption + "']"));

        }
        public IWebElement SelectItem(string itemName)
        {
            return _driver.FindElement(By.XPath("//a[@class='product_img_link']//img[@title ='" + itemName + "']"));
        }

        public IWebElement AddToCart => _driver.FindElement(By.XPath("//p[@id='add_to_cart']/button/span"));

        public IWebElement AddToCartSuccessMessage => _driver.FindElement(By.XPath("//span[@title='Close window']/following::h2"));

        public IWebElement SearchAnItem => _driver.FindElement(By.Id("search_query_top"));

        public IWebElement SubmitSearch => _driver.FindElement(By.Name("submit_search"));

        public IWebElement SearchListHeading => _driver.FindElement(By.XPath("//span[@class='lighter']"));
    }
}
