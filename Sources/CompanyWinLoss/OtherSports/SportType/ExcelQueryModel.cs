using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.OtherSports.SportType
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
