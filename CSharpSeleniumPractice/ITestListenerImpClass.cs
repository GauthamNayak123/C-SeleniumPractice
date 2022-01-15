using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumPractice
{
    internal class ITestListenerImpClass : ITestListener
    {
        public void TestFinished(ITestResult result)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string methodName=result.Test.MethodName.ToString();
            
            string filePath = @"C:\Users\Dell\source\repos\CSharpSeleniumPractice\CSharpSeleniumPractice\TestOutput\";
            string name = filePath +methodName+ date + ".png";

            ((ITakesScreenshot)BaseClass.driver1).GetScreenshot().SaveAsFile(name, ScreenshotImageFormat.Png);
        }

        void ITestListener.SendMessage(TestMessage message)
        {
            throw new NotImplementedException();
        }

        void ITestListener.TestOutput(TestOutput output)
        {
            throw new NotImplementedException();
        }

        void ITestListener.TestStarted(ITest test)
        {
            throw new NotImplementedException();
        }
    }
}
