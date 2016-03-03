using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Casino.BetType
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}