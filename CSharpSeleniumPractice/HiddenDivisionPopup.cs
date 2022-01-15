using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumPractice
{
    internal class HiddenDivisionPopup
    {
        public TestContext TestContext { get; set; }
        public WebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            

        }

        [SetUp]
        public void LaunchBrowser()
        {
            driver.Navigate().GoToUrl(TestContext.Parameters.Get("URL"));
        }

        [Test]
        public void Test()
        {
            driver.FindElement(By.Id("ddate")).Click();
           
        }

        [OneTimeTearDown]
        public void TearSetup()
        {
            driver.Quit();
        }
    }
}
