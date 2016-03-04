using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Keno.BetType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}