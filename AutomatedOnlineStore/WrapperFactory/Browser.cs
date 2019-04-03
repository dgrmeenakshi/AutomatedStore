using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace AutomatedOnlineStore.WrapperFactory
{
    public class Browser
    {
        private static IWebDriver
            _driver; // there is only one copy for all the instances of class and static method/classes can't be overriden/inherited

        private static string _url;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    throw
                        new NullReferenceException(
                            "Webdriver reference is null"); // this method may throw some exception and it can be handled in try/catch block
                }

                return _driver;
            }
            private set { _driver = value; }
        }

        private static string URL
        {
            get { return _url; }
            set { _url = value; }
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "FireFox":
                    Driver = new FirefoxDriver();
                    Driver.Manage().Window.Maximize();
                    break;
                case "IE":
                    Driver = new InternetExplorerDriver();
                    Driver.Manage().Window.Maximize();
                    break;
                case "Chrome":
                    Driver = new ChromeDriver();
                    Driver.Manage().Window.Maximize();
                    break;
            }
        }

        public static  void LaunchApplication(string url)
        {
            Driver.Navigate().GoToUrl(URL);
            Driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromMilliseconds(100);
        }
         
        
    }
}
