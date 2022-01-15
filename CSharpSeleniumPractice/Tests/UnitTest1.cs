using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSharpSeleniumPractice
{
    
    public class Tests1
    {
        public TestContext TestContext { get; set; }
        public  WebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(15);
         
        }

        [SetUp]
        public void LaunchBrowser()
        {
            driver.Navigate().GoToUrl(TestContext.Parameters.Get("URL"));
        }

        [Test]
        public void Test1()
        {
            driver.FindElement(By.Name("user_name")).SendKeys(TestContext.Parameters.Get("username"));
            driver.FindElement(By.Name("user_password")).SendKeys(TestContext.Parameters.Get("password"));
            IWebElement loginButton = driver.FindElement(By.Id("submitButton"));

            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(15));

            IWebElement searchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(loginButton));
            
            searchResult.Click();

        }

        [Test]
        
        public void Test2()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("//img[@src='themes/softed/images/user.PNG']"))).Perform();
            IWebElement signOut = driver.FindElement(By.LinkText("Sign Out"));
            signOut.Click();
        }

        [OneTimeTearDown]
        public void TearSetup()
        {
            driver.Quit();
        }
    }
}