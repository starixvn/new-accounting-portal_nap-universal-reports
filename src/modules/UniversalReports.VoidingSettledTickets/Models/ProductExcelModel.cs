using Epplus.Mapper.Annotations;

namespace UniversalReports.VoidingSettledTickets.Models
{
    public class ProductExcelModel
    {
        [Cell("A4")]
        public string ProductGroup { get; set; }

        [Cell("B4")]
        public decimal HouseIncomeBeforeExtraPT { get; set; }

        [Cell("C4")]
        public decimal HouseIncomeAfterExtraPT { get; set; }
    }
}