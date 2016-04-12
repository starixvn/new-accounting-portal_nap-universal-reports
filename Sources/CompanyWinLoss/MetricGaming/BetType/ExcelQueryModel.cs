using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.MetricGaming.BetType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
