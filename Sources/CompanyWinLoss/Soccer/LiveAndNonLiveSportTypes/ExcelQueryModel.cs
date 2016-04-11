namespace UniversalReports.CompanyWinLoss.Soccer.LiveAndNonLiveSportTypes
{
    using System.ComponentModel.DataAnnotations;

    class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
