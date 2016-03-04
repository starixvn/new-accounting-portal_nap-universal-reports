using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Cockfighting.BetType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}