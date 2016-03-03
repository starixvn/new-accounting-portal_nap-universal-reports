using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.NumberGame.Site
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}