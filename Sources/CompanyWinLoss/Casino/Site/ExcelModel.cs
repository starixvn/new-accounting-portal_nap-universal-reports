using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Casino.Site
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}