using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Keno.Site
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}