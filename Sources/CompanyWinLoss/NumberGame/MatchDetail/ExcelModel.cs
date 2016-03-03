using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.NumberGame.MatchDetail
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}