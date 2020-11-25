using BookShopTrainingApp.Application.PurchasesReport;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookShopTrainingApp.Web.Reports
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportingService reportingService;

        public ReportController(IReportingService reportingService)
        {
            this.reportingService = reportingService;
        }

        [HttpPost("/purchase")]
        public async Task<HttpResponseMessage> Get(ReportSpeciffications speciffications)
        {
            //This is not a good example for generating reports
            //Reports should be generated on a background thread
            //This type of requests should be made in a HttpGet endpoint
            //This report generator is created for testing purposes only

            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            var report = await reportingService.Generate(speciffications);

            var biteArray = report.GetAsByteArray();
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var datastream = new MemoryStream(biteArray);
            result.Content = new StreamContent(datastream);
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = "Report.xlsx";
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            return result;
        }
    }
}