using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProyectNew.PageObject;
using SeleniumProyectNew.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProyectNew.TestCase
{
    [TestFixture]
    public class LoginTest :BaseTest
    {
        
        [Test]
        public void SussefullLoginTest ()
        {
            string user = "admin";
            string password = "admin123";
            LoginPage loginPage = new LoginPage(Driver);
            test.Info($"Login whit user: '{user}' and password: '{password}'");
            EmployeePage employeePage = loginPage.Loging(user, password);
            test.Info("Verifying that the Login Page in opened");
            Assert.IsTrue(employeePage.FormIspresent());
          

        }
        
    }
}
