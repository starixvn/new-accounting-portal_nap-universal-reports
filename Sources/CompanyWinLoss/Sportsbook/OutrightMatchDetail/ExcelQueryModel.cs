using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Sportsbook.OutrightMatchDetail
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}