using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.LiveCasino.BetType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}