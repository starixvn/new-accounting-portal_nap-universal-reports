namespace UniversalReports.CompanyWinLoss.Soccer.MajorOrMinorBetTypes
{
    using System.ComponentModel.DataAnnotations;

    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
