using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.MainReport;
using NSubstitute;
using NUnit.Framework;

namespace NAP.Reports.Services.Tests
{
    public class ProductWinLossServiceTests : ReportServiceBaseTests
    {
        [Test]
        [Category("Integration-Data-Service")]
        public void Query_DateRangeForThreeSources()
        {
            // Arrange
            var productWinLossService = CreateProductWinLossService();

            // Act
            productWinLossService.Query("NumberGame", MainReportQuery);
        }

        private ProductWinLossService CreateProductWinLossService()
        {
            var balanceUpService = Substitute.For<IBalanceUpService>();
            balanceUpService.Query().Returns(BalanceUpRange);
            var balanceUpSourceChooser = new BalanceUpSourceChooser(balanceUpService);

            var dynamicRepository = new DynamicRepository();
            var calculationService = new CalculationService();
            return new ProductWinLossService(dynamicRepository, calculationService, balanceUpSourceChooser);
        }
    }
}
