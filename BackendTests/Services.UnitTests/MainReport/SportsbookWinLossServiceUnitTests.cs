using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Services.MainReport;
using NAP.Reports.CompanyWinLoss.Services.Models;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests.MainReport
{
    public class SportsbookWinLossServiceUnitTests
    {
        [Test]
        [Category("ServiceUnitTests")]
        public void QueryBySource_FourRawWinLoss_CallCalculationServiceFourTimes()
        {
            // Arrange
            var fakeData = CreateFakeRawWinLosses();

            var calculationService = Substitute.For<ICalculationService>();
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            dynamicRepository.Fetch<RawWinLoss>(Arg.Any<ICriteria>()).Returns(fakeData);

            var balanceUpSourceChooser = Substitute.For<IBalanceUpSourceChooser>();
            var service = new SportsbookWinLossService(dynamicRepository, calculationService, balanceUpSourceChooser);

            // Act
            var balanceUpSource = new BalanceUpSource();
            var result = service.QueryBySource(balanceUpSource);

            // Assert
            calculationService.Received(4).FromRawWinLoss(Arg.Any<RawWinLoss>());
        }

        private List<RawWinLoss> CreateFakeRawWinLosses()
        {
            var liveWinLoss = WinLossFactory.CreateRawWinLoss("Sportsbook Live", 100, 200, 10, 300, 400, 1000, 1200);
            var nonLiveWinLoss = WinLossFactory.CreateRawWinLoss("Sportsbook Non-Live", 110, 210, 20, 310, 410, 1100, 1300);
            var parlayWinLoss = WinLossFactory.CreateRawWinLoss("Parlay", 120, 220, 30, 320, 420, 1200, 1400);
            var outrightWinLoss = WinLossFactory.CreateRawWinLoss("Outright", 130, 230, 40, 330, 430, 1300, 1500);

            return new List<RawWinLoss> { liveWinLoss, nonLiveWinLoss, parlayWinLoss, outrightWinLoss };
        }
    }
}
