using System;
using System.Collections.Generic;
using NUnit.Framework;
using Excel = Microsoft.Office.Interop.Excel;

namespace AutomationFramework
{
    class ExcelReader
    {
        public List<TestCaseData> ReadExcelData(string ExcelFilePath, string tab)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(ExcelFilePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[tab];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            List<TestCaseData> ret = new List<TestCaseData>();

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            try
            {
                for (int i = 2; i <= rowCount; i++)
                {
                    var row = new List<string>();
                    for (int j = 1; j <= colCount; j++)
                    {
                        row.Add(xlRange.Cells[i, j].Value2.ToString());
                    }
                    //Add a new row to the list
                    ret.Add(new TestCaseData(row.ToArray()));

                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error processing file {0}. Message {1}", ExcelFilePath, e.Message);
            }

            finally
            {
                // Close *.xls
                xlWorkbook.Close();
                xlApp.Quit();
            }

            return ret;
        }
    }
}
