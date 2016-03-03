using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.LiveCasino.ThirdPartyProduct
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}