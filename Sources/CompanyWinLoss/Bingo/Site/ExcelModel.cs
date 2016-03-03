using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Bingo.Site
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}