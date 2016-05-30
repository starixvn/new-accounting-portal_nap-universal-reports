using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.MetricGaming.LiveNonLive
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string BetTypeTitle { get; set; }

        [Required]
        public string LiveNonLiveTitle { get; set; }
    }
}
