using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class ExcelModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}