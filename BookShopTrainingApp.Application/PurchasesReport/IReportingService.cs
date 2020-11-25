using OfficeOpenXml;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Application.PurchasesReport
{
    public interface IReportingService
    {
        Task<ExcelPackage> Generate(ReportSpeciffications speciffications);
    }
}