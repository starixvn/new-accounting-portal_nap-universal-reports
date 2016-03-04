using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Casino.BetType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}