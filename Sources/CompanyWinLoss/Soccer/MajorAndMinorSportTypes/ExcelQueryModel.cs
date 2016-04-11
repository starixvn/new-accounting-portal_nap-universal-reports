namespace UniversalReports.CompanyWinLoss.Soccer.MajorAndMinorSportTypes
{
    using System.ComponentModel.DataAnnotations;

    public class ExcelQueryModel : QueryModel
    {
        [Required]
        public string Title { get; set; }
    }
}
