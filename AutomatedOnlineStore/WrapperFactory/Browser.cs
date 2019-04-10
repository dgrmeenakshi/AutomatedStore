using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace AutomatedOnlineStore.WrapperFactory
{
    public class Browser
    {
        private static IWebDriver _driver;

        private static string _url = ConfigurationManager.AppSettings["url"];
        private static string _browser = ConfigurationManager.AppSettings["browser"];

    

        public static IWebDriver Driver
        {
            get
            {
               return _driver;
            }
            private set { _driver = value; }
        }

        private static string URL
        {
            get { return _url; }
            set { _url = value; }
        }


        public static void InitBrowser()
        {
            switch (_browser)
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
            LaunchApplication();
        }

        public static void LaunchApplication()
        {
            Driver.Navigate().GoToUrl(URL);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100);
        }
        public static void Close()
        {
            Driver.Quit();
        }


    }
}
