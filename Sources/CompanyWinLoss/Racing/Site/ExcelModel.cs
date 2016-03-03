using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Racing.Site
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}