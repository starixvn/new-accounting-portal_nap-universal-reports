using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Keno.Site
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}