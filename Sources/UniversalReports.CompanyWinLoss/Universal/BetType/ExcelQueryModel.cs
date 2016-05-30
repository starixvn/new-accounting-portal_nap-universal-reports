using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Universal.BetType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}