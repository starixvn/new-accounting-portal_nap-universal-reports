using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.OtherSports.LiveNonLive
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string SportTypeTitle { get; set; }

        [Required]
        public string LiveNonLiveTitle { get; set; }
    }
}