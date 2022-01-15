using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumPractice.ObjectRepo
{
    internal class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement userNameEdt => driver.FindElement(By.Name("user_name"));
        public IWebElement userPasswordEdt => driver.FindElement(By.Name("user_password"));
        public IWebElement loginBtn => driver.FindElement(By.Id("submitButton"));

        public void LoginToApp(string userName,string passWord)
        {
            userNameEdt.SendKeys(userName);
            userPasswordEdt.SendKeys(passWord);
            loginBtn.Click();
        }
    }
}
