namespace UniversalReports.CompanyWinLoss.Soccer.LiveNonLiveSportTypes
{
    using System.ComponentModel.DataAnnotations;

    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
