namespace UniversalReports.CompanyWinLoss.Soccer.LiveNonLiveSportTypes
{
    using System.ComponentModel.DataAnnotations;

    class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
