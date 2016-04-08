using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.LiveAndNoneLive.Site
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}