using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.OtherSports.BetType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
