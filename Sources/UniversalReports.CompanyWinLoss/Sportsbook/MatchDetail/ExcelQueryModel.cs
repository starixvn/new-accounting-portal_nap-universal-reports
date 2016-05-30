using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Sportsbook.MatchDetail
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}