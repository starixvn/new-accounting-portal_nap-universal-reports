namespace UniversalReports.CompanyWinLoss.Soccer.MajorMinor
{
    using System.ComponentModel.DataAnnotations;

    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
