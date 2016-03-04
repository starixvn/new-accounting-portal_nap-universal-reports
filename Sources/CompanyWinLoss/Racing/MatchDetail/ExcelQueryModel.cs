using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Racing.MatchDetail
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}