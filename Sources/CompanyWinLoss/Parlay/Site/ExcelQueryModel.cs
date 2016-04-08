using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Parlay.Site
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}