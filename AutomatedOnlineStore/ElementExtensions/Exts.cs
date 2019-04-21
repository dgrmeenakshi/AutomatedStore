using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomatedOnlineStore.ElementExtensions
{
   public static class Exts
    {
        public static void Hover(this IWebElement elementToHover, IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(elementToHover).Perform();
        }

    }
}
