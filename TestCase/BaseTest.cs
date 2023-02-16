using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using System.Configuration;
using NUnit.Framework.Interfaces;
using SeleniumProyectNew.Handler;
using AventStack.ExtentReports;
using OpenQA.Selenium.DevTools.V107.DOM;
using SeleniumProyectNew.Utils;

namespace SeleniumProyectNew.TestCase
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;
        protected string Url = ConfigurationManager.AppSettings["Url"];
        protected ExtentTest test;


        [SetUp]
        public void BeforeBaseTest()
        {
            test = ReportManager.Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(Url);
        }
        [TearDown]
        public void AfterBaseTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;
            var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";

            switch (status)
            {
                case TestStatus.Failed:
                    test.Fail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                    test.AddScreenCaptureFromPath(ScreenShotHandler.TakeScreenShot(Driver));
                    break;
                case TestStatus.Skipped:
                    test.Skip("Test skipped!");
                    break;
                default:
                    test.Pass("Test Executed Sucessfully!");
                    break;
            }
            if (Driver != null)
            {
                Driver.Quit();
            }
        }
        [OneTimeTearDown]
        public void CloseAll()
        {
            try
            {
                ReportManager.Extent.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}

