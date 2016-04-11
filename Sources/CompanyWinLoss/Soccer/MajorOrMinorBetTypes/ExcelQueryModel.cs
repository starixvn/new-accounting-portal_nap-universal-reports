namespace UniversalReports.CompanyWinLoss.Soccer.MajorOrMinorBetTypes
{
    using System.ComponentModel.DataAnnotations;

    class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
