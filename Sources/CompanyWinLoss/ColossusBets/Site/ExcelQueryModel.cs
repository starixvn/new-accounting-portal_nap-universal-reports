using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.ColossusBets.Site
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}