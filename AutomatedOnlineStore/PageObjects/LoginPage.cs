using OpenQA.Selenium;



namespace AutomatedOnlineStore.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement _signIn
        {
            get { return _driver.FindElement(By.XPath("//a[@class='login']")); }
        }

        private IWebElement _email
        {
            get { return _driver.FindElement(By.Id("email")); }
        }

        private IWebElement _password
        {
            get { return _driver.FindElement(By.Id("passwd")); }
        }

        private IWebElement _submit
        {
            get { return _driver.FindElement(By.Id("SubmitLogin")); }
        }

        private IWebElement _errorMessage
        {
            get { return _driver.FindElement(By.XPath("//div[@class='alert alert-danger']/ol/li")); }
        }

        public void Login(string userName, string passwd)
        {
            _signIn.Click();
            _email.SendKeys(userName);
            _password.SendKeys(passwd);
            _submit.Submit();
        }

        public string ErrorMessage()
        {
            return _errorMessage.Text;
        }
    }
}
