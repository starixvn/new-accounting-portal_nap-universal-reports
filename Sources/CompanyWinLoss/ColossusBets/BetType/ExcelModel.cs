using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.ColossusBets.BetType
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}