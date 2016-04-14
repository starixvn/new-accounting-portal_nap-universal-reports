namespace UniversalReports.CompanyWinLoss.Soccer.LiveNonLive
{
    using System.ComponentModel.DataAnnotations;

    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
