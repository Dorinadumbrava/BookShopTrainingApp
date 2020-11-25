using BookShopTrainingApp.Core.Extensions;
using BookShopTrainingApp.Persistence;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Application.PurchasesReport
{
    public class ReportingService : IReportingService
    {
        private readonly IBookShopContext context;
        private readonly IExcelCreator excelCreator;

        public ReportingService(IBookShopContext context, IExcelCreator excelCreator)
        {
            this.context = context;
            this.excelCreator = excelCreator;
        }
        public async Task<ExcelPackage> Generate(ReportSpeciffications speciffications)
        {
            var purchases = await context.Purchases.Include(x => x.Customer).Include(x => x.Book)
                .OrderBy(x => x.PurcahseTime)
                .WhereIf(speciffications.BookId.HasValue, x => x.BookId == speciffications.BookId)
                .WhereIf(speciffications.CustomerId.HasValue, x => x.CustomerId == speciffications.CustomerId)
                .WhereIf(speciffications.StartDate.HasValue, x => x.PurcahseTime >= speciffications.StartDate)
                .WhereIf(speciffications.EndDate.HasValue, x => x.PurcahseTime <= speciffications.EndDate).ToListAsync();
            var report =  excelCreator.CreateExcel(purchases);
            return report;

        }
    }
}