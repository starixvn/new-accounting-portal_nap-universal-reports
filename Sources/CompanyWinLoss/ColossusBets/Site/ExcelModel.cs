using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.ColossusBets.Site
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}