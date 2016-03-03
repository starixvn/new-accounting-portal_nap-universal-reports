using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.VirtualSports.Site
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}