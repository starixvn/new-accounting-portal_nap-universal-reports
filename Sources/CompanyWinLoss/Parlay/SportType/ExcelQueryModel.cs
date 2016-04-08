using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Parlay.SportType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
