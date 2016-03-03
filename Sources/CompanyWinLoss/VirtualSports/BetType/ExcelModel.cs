using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.VirtualSports.BetType
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}