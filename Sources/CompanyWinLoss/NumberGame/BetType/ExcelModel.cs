using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}