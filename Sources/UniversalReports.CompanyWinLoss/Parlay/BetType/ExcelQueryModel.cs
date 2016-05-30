using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Parlay.BetType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
