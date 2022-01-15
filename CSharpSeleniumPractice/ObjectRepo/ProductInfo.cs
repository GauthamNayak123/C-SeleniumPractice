using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumPractice.ObjectRepo
{
    internal class ProductInfo
    {
        IWebDriver driver;
        public ProductInfo(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement createProductImg => driver.FindElement(By.CssSelector("img[src = 'themes/softed/images/btnL3Add.gif']"));
        public IWebElement succesfulMsg => driver.FindElement(By.CssSelector("span[class='lvtHeaderText']"));

    }
}
