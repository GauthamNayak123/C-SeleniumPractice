
using AutoItX3Lib;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CSharpSeleniumPractice
{
    internal class PopupHandling
    {
        [Test]
        public void HandlePopup()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(15);
            driver.Navigate().GoToUrl("https://www.naukri.com/");

            driver.FindElement(By.XPath("//div[text()='Register']")).Click();

            string current = driver.CurrentWindowHandle;

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            driver.FindElement(By.XPath("//button[text()='Upload Resume']")).Click();

            System.Threading.Thread.Sleep(3000);

            
                AutoItX3 auto = new AutoItX3();
                auto.Sleep(3000);
                auto.Send("‪E:/SkillraryResume.docx");
                auto.Send("{ENTER}");
                auto.Sleep(2000);
            
           
            driver.Quit();
            

        }

    }
}
