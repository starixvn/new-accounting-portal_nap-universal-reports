using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.NumberGame.Site
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}