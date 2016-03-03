using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.VirtualSports.RacingDetail
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}