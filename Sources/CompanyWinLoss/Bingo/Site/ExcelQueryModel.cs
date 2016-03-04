using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Bingo.Site
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}