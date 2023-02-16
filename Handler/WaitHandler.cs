using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProyectNew.Handler
{
    public class WaitHandler
    {
        public static bool ElementIsPresent(IWebDriver driver, By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                wait.Until(drv => drv.FindElement(locator));
                return true;
            }
            catch 
            {

            }
            return false;
        }
           
    }
}
