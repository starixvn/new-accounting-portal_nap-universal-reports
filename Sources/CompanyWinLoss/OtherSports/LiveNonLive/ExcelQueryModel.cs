using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.OtherSports.LiveNonLive
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
