using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.MetricGaming.LiveNonLive
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
