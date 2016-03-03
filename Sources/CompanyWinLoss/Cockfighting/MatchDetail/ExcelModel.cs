using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}