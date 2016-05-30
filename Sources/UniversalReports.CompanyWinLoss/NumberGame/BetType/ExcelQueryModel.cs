using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string LiveTitle { get; set; }

        [Required]
        public string NonLiveTitle { get; set; }
    }
}