using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.Services.MainReport;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests.MainReport
{
    public class MainReportServiceUnitTests : MainReportServiceBaseTests
    {
        [Test]
        [Category("ServiceUnitTests")]
        public void Query_SportsbookAndNumberGame_CallAllOtherServices()
        {
            // Arrange            
            var calculationService = Substitute.For<ICalculationService>();
            var configuration = Substitute.For<IConfiguration>();
            configuration.Products.Returns(new List<string> { "Sportsbook", "NumberGame" });

            Initialize();

            // Act 
            MainReportService = new MainReportService(SportsbookWinLossService, ProductWinLossService, calculationService, configuration);
            var result = MainReportService.Query(Query);

            // Assert
            ProductWinLossService.Received(1).Query(NumberGame, Query);
            ProductWinLossService.Received(1).Query(Sportsbook, Query);
            SportsbookWinLossService.Received(1).Query(Query);
            calculationService.Received().CalculateSum(Arg.Any<string>(), Arg.Any<IEnumerable<WinLoss>>());
        }
    }
}
