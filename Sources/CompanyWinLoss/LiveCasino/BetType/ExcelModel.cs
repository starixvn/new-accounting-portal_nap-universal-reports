using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.LiveCasino.BetType
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}