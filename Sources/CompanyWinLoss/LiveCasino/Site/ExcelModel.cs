using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.LiveCasino.Site
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}