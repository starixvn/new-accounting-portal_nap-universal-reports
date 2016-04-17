using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Casino.Product
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}