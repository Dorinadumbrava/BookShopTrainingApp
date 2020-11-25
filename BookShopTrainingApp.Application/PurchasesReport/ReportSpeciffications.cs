using System;
using System.ComponentModel.DataAnnotations;

namespace BookShopTrainingApp.Application.PurchasesReport
{
    public class ReportSpeciffications
    {
        [Range(0, int.MaxValue)]
        public int? CustomerId { get; set; }
        [Range(0, int.MaxValue)]
        public int? BookId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}