using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumPractice.Tests
{
    internal class ScreenshotTest:BaseClass
    {
        [Test]
        public void TakeScreenshotTest()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string filePath = @"C:\Users\Dell\source\repos\CSharpSeleniumPractice\CSharpSeleniumPractice\TestOutput\";
            string name = filePath + date + ".png";

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(name, ScreenshotImageFormat.Png);
        }

    }
}
