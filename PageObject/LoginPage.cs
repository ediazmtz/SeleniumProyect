using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProyectNew.PageObject
{
    public class LoginPage :BasePage
    {
        
        protected By UserInput = By.Id("user");
        protected By PasswordInput = By.Id("pass");
        protected By ButtonLogin = By.Id("loginButton");

        public LoginPage (IWebDriver driver)
        {
            Driver = driver;
            if (!Driver.Title.Equals("AUT Login – TestFaceClub"))
                throw new Exception("This is not login page");
        }

        public void TypeUserLogin(string user)
        {
          Driver.FindElement(UserInput).SendKeys(user);
           
        }

        public void TypePassLogin(string pass)
        {
            Driver.FindElement(PasswordInput).SendKeys(pass);

        }
        public void ClickLogin()
        {
            Driver.FindElement(ButtonLogin).Click();

        }

        public  EmployeePage Loging (string user, string password)
        {
            TypeUserLogin(user);
            TypePassLogin(password);
            ClickLogin();
            return new EmployeePage(Driver);

        }
    }
}
