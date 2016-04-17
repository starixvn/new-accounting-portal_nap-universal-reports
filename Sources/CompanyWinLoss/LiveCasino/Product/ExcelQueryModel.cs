using System.ComponentModel.DataAnnotations;

namespace UniversalReports.CompanyWinLoss.LiveCasino.Product
{
    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}