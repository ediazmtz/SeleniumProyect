using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProyectNew.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProyectNew.TestCase
{
    [TestFixture]
    public class AddEmployeeTest :BaseTest
    {
        
        private EmployeePage EmployeePage;

        [SetUp]
        public void BeforeTest()
        {
            LoginPage loginPage = new LoginPage(Driver);
            EmployeePage = loginPage.Loging("admin", "admin123");
        }
        [TestCase("eli", "eli@gmail.com", "zona", "0123456")]
        public void SucessFullAddEmployee (string name,string email,string address,string phone ) 
        {
           
            EmployeePage.AddEmployee(name,email,address,phone);
            Assert.IsTrue(EmployeePage.IsSucessAlertPresent() );
        }

    }
}
