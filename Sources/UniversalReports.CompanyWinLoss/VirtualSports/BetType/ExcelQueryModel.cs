using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.VirtualSports.BetType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}