using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumPractice
{
    internal class CreateLeadTest
    {
        public TestContext TestContext { get; set; }
        public WebDriver driver;
        private static Logger _logger=LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public void Setup()
        {
           
            driver = new ChromeDriver();
            _logger.Info("launched the browser");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }

        [SetUp]
        public void LaunchBrowser()
        {
            var Url = TestContext.Parameters.Get("URL");
            driver.Navigate().GoToUrl(Url);
            _logger.Info($"navigate to the Url=>{Url}");
        }

        [Test]
        public void Test()
        {
            driver.FindElement(By.Name("user_name")).SendKeys(TestContext.Parameters.Get("username"));
            driver.FindElement(By.Name("user_password")).SendKeys(TestContext.Parameters.Get("password"));
            IWebElement loginButton = driver.FindElement(By.Id("submitButton"));

            loginButton.Click();

            driver.FindElement(By.LinkText("Leads")).Click();
            driver.FindElement(By.XPath("//img[@src='themes/softed/images/btnL3Add.gif']")).Click();

            IWebElement firstNameDropDown = driver.FindElement(By.Name("salutationtype"));
            SelectElement select=new SelectElement(firstNameDropDown);
            select.SelectByValue("Mr.");
           
            driver.FindElement(By.Name("firstname")).SendKeys("Root");

            driver.FindElement(By.Name("lastname")).SendKeys("Williams");

            driver.FindElement(By.Name("company")).SendKeys("amc tech");

            driver.FindElement(By.XPath("//input[@title='Save [Alt+S]']")).Click();


        }

        [Test]
        public void Test2()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("//img[@src='themes/softed/images/user.PNG']"))).Perform();
            driver.FindElement(By.LinkText("Sign Out")).Click();
        }

        [OneTimeTearDown]
        public void TearSetup()
        {
            driver.Quit();
        }
    }
}
