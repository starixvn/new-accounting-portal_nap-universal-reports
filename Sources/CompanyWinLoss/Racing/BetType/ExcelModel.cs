using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Racing.BetType
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}