using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Universal.Site
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}