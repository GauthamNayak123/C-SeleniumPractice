using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumPractice
{
    internal class ScrollTest
    {
        [Test]
        public void Scroll()
        {
            IWebDriver driver=new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.yesbank.in/");

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

          

           // jse.ExecuteScript("scrollBy(0,500)");

          //  System.Threading.Thread.Sleep(3000);         

            driver.Quit();
        }
    }
}
