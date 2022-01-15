using CSharpSeleniumPractice.ObjectRepo;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumPractice
{
    internal class BaseClass
    {
        
        public IWebDriver driver;
        public static IWebDriver driver1;

        

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Navigate().GoToUrl(TestContext.Parameters.Get("URL"));
            driver1 = driver;


        }
        [SetUp]
        public void Login()
        {
            LoginPage lp = new LoginPage(driver);
            lp.LoginToApp("admin", "admin");
        }
        [TearDown]
        public void Logout()
        {
            LoginPage lp = new LoginPage(driver);
            HomePage hp = new HomePage(driver);
            hp.LogOut();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("submitButton")));
        }
        [OneTimeTearDown]
        public void TearSetup()
        {
            driver.Quit();
        }
    }
}
