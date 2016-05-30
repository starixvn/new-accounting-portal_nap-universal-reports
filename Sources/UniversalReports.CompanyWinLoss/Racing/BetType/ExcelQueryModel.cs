using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Racing.BetType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}