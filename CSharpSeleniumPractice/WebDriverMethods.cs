using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CSharpSeleniumPractice
{
    internal class WebDriverMethods:BaseClass
    {
        

        [Test]
    public void GetTextTest()
        {

            try
            {// get the path of the currently executing assembly
                string currentPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                // get the directory name of the current assembly
                string directory = Path.GetDirectoryName(currentPath);
                DirectoryInfo info = new DirectoryInfo(directory);
                string path = info.Parent.Parent.Parent.FullName;

                Screenshot dd = ((ITakesScreenshot)driver).GetScreenshot();
                string imagename = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
                string date = DateTime.Today.ToString("dd-MM-yyyy");

                //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().Name);
                // path = path.Substring(6);
                string TestResultLocation = path + "/TestOutput/FailedTests " + date;

                if (Directory.Exists(TestResultLocation) == false)
                {
                    Directory.CreateDirectory(TestResultLocation);
                }
                string localPathName = TestResultLocation + "/" + "testName";

                if (Directory.Exists(localPathName) == false)
                {
                    Directory.CreateDirectory(localPathName);
                }
                dd.SaveAsFile(localPathName + "/" + imagename + ".png", ScreenshotImageFormat.Png);


            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);   
            }
            

        }

    }
}
