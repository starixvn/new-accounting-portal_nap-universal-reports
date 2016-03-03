using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Bingo.BetType
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}