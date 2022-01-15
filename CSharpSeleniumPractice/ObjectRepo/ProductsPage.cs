using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumPractice.ObjectRepo
{
    internal class ProductsPage
    {
        IWebDriver driver;
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
          
        }

        public IWebElement createProductImg => driver.FindElement(By.CssSelector("img[title='Create Product...']"));
        public IWebElement searchForTxtField => driver.FindElement(By.Name("search_text"));
        public IWebElement inDropDown => driver.FindElement(By.Id("bas_searchfield"));
        public IWebElement searchNowBtn => driver.FindElement(By.Name("submit"));
        public IWebElement deleteBtn => driver.FindElement(By.XPath("//input[@value='Delete']"));
        public IWebElement massEditBtn => driver.FindElement(By.XPath("//input[@value='Mass Edit']"));
        public IWebElement selectAllCheckBox => driver.FindElement(By.Id("selectCurrentPageRec"));
        public IReadOnlyCollection<IWebElement> productNameList => driver.FindElements(By.XPath("//a[@title='Products']"));
        public IWebElement loadingImg => driver.FindElement(By.XPath("//img[@src='themes/softed/images/status.gif']"));
        public IWebElement noProductsFoundMsg => driver.FindElement(By.XPath("//span[contains(text(),'No Product Found')]"));

        public void SearchByAlphabet(string ch)
        {
            driver.FindElement(By.XPath("//td[text()='" + ch + "']")).Click();
        }
    }
}
