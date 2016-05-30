using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}