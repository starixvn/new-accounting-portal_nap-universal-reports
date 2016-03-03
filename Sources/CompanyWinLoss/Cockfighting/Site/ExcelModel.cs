using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Cockfighting.Site
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}