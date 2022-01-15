using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumPractice.ObjectRepo
{
    internal class HomePage
    {
		IWebDriver driver;

		public HomePage(IWebDriver driver)
		{
			this.driver = driver;
			
		}

		public IWebElement contactsLink => driver.FindElement(By.LinkText("Contacts"));
		public IWebElement organizationLink => driver.FindElement(By.LinkText("Organizations"));
		public IWebElement productLink => driver.FindElement(By.LinkText("Products"));
		public IWebElement administratorImg => driver.FindElement(By.XPath("//img[@src='themes/softed/images/user.PNG']"));
		public IWebElement signOutLink => driver.FindElement(By.LinkText("Sign Out"));

		public void LogOut()
		{
			Actions action = new Actions(driver);
			action.MoveToElement(administratorImg).Perform();
			signOutLink.Click();
		}
	}
}
