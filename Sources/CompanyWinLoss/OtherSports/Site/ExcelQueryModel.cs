using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.OtherSports.Site
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}