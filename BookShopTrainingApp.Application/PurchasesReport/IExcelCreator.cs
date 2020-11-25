using System.Collections.Generic;
using BookShopTrainingApp.Domain;
using OfficeOpenXml;

namespace BookShopTrainingApp.Application.PurchasesReport
{
    public interface IExcelCreator
    {
        ExcelPackage CreateExcel(IEnumerable<Purchase> purchases);
    }
}