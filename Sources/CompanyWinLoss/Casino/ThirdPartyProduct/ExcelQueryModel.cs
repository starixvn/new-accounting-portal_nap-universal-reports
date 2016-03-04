using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Casino.ThirdPartyProduct
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}