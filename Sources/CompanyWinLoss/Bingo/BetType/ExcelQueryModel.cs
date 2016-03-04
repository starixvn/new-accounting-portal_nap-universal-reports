using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Bingo.BetType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}