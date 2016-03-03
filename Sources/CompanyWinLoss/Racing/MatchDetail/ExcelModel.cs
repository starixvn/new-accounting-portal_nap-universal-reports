using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Racing.MatchDetail
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}