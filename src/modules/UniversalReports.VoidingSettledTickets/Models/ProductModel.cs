namespace UniversalReports.VoidingSettledTickets.Models
{
    public class ProductModel
    {
        public int? ProductGroupId { get; set; }

        public string ProductGroup { get; set; }

        public decimal HouseIncomeBeforeExtraPT { get; set; }

        public decimal HouseIncomeAfterExtraPT { get; set; }

        public static ProductModel operator +(ProductModel a, ProductModel b)
        {
            return new ProductModel
            {
                ProductGroup = "Total",
                HouseIncomeBeforeExtraPT = a.HouseIncomeBeforeExtraPT + b.HouseIncomeBeforeExtraPT,
                HouseIncomeAfterExtraPT = a.HouseIncomeAfterExtraPT + b.HouseIncomeAfterExtraPT,
            };
        }
    }
}