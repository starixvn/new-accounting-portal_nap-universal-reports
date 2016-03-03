using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}