using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Casino.ThirdPartyProduct
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}