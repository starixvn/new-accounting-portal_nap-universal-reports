using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.MetricGaming.Site
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}