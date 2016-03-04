using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}