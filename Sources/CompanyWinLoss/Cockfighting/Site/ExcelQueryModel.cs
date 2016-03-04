using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Cockfighting.Site
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}