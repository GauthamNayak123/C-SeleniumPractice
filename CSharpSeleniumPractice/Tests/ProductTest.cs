using CSharpSeleniumPractice.ObjectRepo;
using CSharpSeleniumPractice.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumPractice.Tests
{
    
    
    internal class ProductTest:BaseClass
    {
       public ExcelUtility eLib=new ExcelUtility();

        [Test, Order(1)]
        public void searchProductByAlphabetTest()
        {
            Random ran = new Random();
            int randomNumber = ran.Next(100);
            string prName = eLib.GetDataFromExcel(0, 0, 0)+randomNumber;
            string prName2 = eLib.GetDataFromExcel(0, 0, 1)+randomNumber;
            string ch = eLib.GetDataFromExcel(0, 0, 2);


            String expectedHomePageTitle = "Administrator - Home - vtiger CRM 5 - Commercial Open Source CRM";
            Assert.AreEqual(expectedHomePageTitle, driver.Title);

            HomePage hm = new HomePage(driver);
            hm.productLink.Click();

            ProductsPage pr = new ProductsPage(driver);
            pr.createProductImg.Click();

            String expectedCreateProductPageTitle = "Administrator - Products - vtiger CRM 5 - Commercial Open Source CRM";
            Assert.AreEqual(expectedCreateProductPageTitle.Trim(), driver.Title);

            CreateNewProductPage cnp = new CreateNewProductPage(driver);
            cnp.CreateProduct(prName);

            ProductInfo pInfo = new ProductInfo(driver);

            Assert.True(pInfo.succesfulMsg.Text.Contains(prName));

            pr.createProductImg.Click();

            cnp.CreateProduct(prName2);

            hm.productLink.Click();

            pr.SearchByAlphabet(ch);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(OpenQA.Selenium.By.XPath("//img[@src='themes/softed/images/status.gif']")));

            bool result = true;

            IReadOnlyCollection<IWebElement> searchResult = pr.productNameList;

          /*  for (int i = 0; i < searchResult.Count; i++)
            {
                if ((searchResult.(i).getText().charAt(0) + "").equalsIgnoreCase(ch))
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }

            } */




        }

        [Test,Order(2)]
        public void DeleteAllProductsTest()
        {
            string ch = eLib.GetDataFromExcel(0, 0, 2);

            HomePage hm=new HomePage(driver);
            hm.productLink.Click();

            ProductsPage pr = new ProductsPage(driver);
            pr.SearchByAlphabet(ch);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(OpenQA.Selenium.By.XPath("//img[@src='themes/softed/images/status.gif']")));

            
            pr.selectAllCheckBox.Click();

            int count = 0;

            while (count <= 20)
            {
                try
                {
                    pr.deleteBtn.Click();
                    break;
                }
                catch (Exception e)
                {
                    count++;
                    System.Threading.Thread.Sleep(100);
                }
            }

            driver.SwitchTo().Alert().Accept();

            System.Threading.Thread.Sleep(4000);


        }
    }
}
