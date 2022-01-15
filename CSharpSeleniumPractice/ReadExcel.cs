using CSharpSeleniumPractice.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumPractice
{
    internal class ReadExcel
    {
        [Test]
        public void Read()
        {
            ExcelUtility eLib = new ExcelUtility();
            string name1 = eLib.GetDataFromExcel(0, 0, 0);
            string name2 = eLib.GetDataFromExcel(0, 0, 1);
            string character= eLib.GetDataFromExcel(0, 0, 2);

            Console.WriteLine(name1);
            Console.WriteLine(name2);
            Console.WriteLine(character);
        }
    }
}
