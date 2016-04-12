namespace UniversalReports.CompanyWinLoss.Soccer.MajorMinorSportTypes
{
    using System.ComponentModel.DataAnnotations;

    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
