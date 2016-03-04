using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Bettrade.Site
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}