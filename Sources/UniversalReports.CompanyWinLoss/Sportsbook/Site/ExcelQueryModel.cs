using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Sportsbook.Site
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}