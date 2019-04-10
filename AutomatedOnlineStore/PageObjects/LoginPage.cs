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

        public IWebElement _signIn
        {
            get { return _driver.FindElement(By.XPath("//a[@class='login']")); }
        }

        public IWebElement _email
        {
            get { return _driver.FindElement(By.Id("email")); }
        }

        public IWebElement _password
        {
            get { return _driver.FindElement(By.Id("passwd")); }
        }

        public IWebElement _submit
        {
            get { return _driver.FindElement(By.Id("SubmitLogin")); }
        }

        public IWebElement _errorMessage
        {
            get { return _driver.FindElement(By.XPath("//div[@class='alert alert-danger']/ol/li")); }
        }

        public IWebElement _successMessage
        {
            get { return _driver.FindElement(By.XPath("//a[@title='View my customer account']")); }
        }

        public void Login(string userName, string passwd)
        {
            _signIn.Click();
            _email.SendKeys(userName);
            _password.SendKeys(passwd);
            _submit.Submit();
        }

        public string SuccessMessage()
        {
            return _successMessage.Text;
        }
    }
}
