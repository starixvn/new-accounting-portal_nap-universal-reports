using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.MetricGaming.MatchDetail
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}