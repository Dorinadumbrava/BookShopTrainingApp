using BookShopTrainingApp.Domain;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;
using NsExcel = Microsoft.Office.Interop.Excel;

namespace BookShopTrainingApp.Application.PurchasesReport
{
    public class ExcelCreator : IExcelCreator
    {
        public ExcelPackage CreateExcel(IEnumerable<Purchase> purchases)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new ExcelPackage();

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");

            if (purchases.Count()>0)
            {
worksheet.Cells["A1"].LoadFromCollection(purchases);
            }
                
            return excelPackage;
        }
    }
}