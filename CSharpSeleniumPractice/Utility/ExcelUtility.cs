using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharpSeleniumPractice.Utility
{
    internal class ExcelUtility
    {
        public string GetDataFromExcel(int sheetNumber,int rowNumber,int cellNumber)
        {

            string path = @"C:\Users\Dell\source\repos\CSharpSeleniumPractice\CSharpSeleniumPractice\TestData\.NetTestData.xlsx";
            
            XSSFWorkbook workbook=new XSSFWorkbook(File.Open(path,FileMode.Open));
            var sheet = workbook.GetSheetAt(sheetNumber);
            var row = sheet.GetRow(rowNumber);
            var cell = row.GetCell(cellNumber);
            return cell.StringCellValue;
            workbook.Close();

        }
    }
}
