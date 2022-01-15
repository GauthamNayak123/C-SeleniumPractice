using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumPractice.ObjectRepo
{
    internal class CreateNewProductPage
    {
        IWebDriver driver;

        public CreateNewProductPage(IWebDriver driver)
        {
            this.driver = driver;   
        }

        public IWebElement productNameTxtField => driver.FindElement(By.Name("productname"));
        public IWebElement qtyInStockTxtField => driver.FindElement(By.Id("qtyinstock"));
        public IWebElement qtyPerUnitTxtField => driver.FindElement(By.Id("qty_per_unit"));
        public IWebElement saveBtn => driver.FindElement(By.CssSelector("input[title='Save [Alt+S]']"));

        public void CreateProduct(string productName)
        {
            productNameTxtField.SendKeys(productName);
            saveBtn.Click();
        }

    }
}
