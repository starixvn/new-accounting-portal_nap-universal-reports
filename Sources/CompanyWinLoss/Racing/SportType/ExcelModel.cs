using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Racing.SportType
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}