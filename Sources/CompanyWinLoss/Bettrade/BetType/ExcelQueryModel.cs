using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Bettrade.BetType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}