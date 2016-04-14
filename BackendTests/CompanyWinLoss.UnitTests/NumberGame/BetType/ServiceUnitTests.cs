using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.NumberGame.BetType;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;
using CommonModels = UniversalReports.CompanyWinLoss.Common.Models;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.NumberGame.BetType
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightNumberGameBetTypeWinLossSummary()
        {
            // Arrange   
            var expectedNumberGameBetTypeWinLossSummary = CreateExpectedNumberGameBetTypeWinLossSummary();
            var commonCalculationService = new CommonServices.CalculationServiceImp();
            var calculationService = new CommonServices.CalculationServiceImp();
            var rawWinLossService = Substitute.For<CommonServices.RawWinLossService>();
            var fakeData = CreateFakeRawWinLoss();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new ServiceImp(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = AreTwoNumberGameBetTypeWinLossSummaryEqual(expectedNumberGameBetTypeWinLossSummary, result);
            Assert.True(equal);
        }

        private WinLossModel CreateExpectedNumberGameBetTypeWinLossSummary()
        {
            var expectedProducts = CreateExpectedListOfBetTypeWinLoss();
            var expectedGrandTotal = CreateExpectedGrandTotal();

            return new WinLossModel
            {
                Live = expectedProducts,
                NonLive = expectedProducts,
                LiveGrandTotal = expectedGrandTotal,
                NonLiveGrandTotal = expectedGrandTotal
            };
        }

        private List<CommonModels.RawWinLoss> CreateFakeRawWinLoss()
        {
            var site1Live = CreateFakeRawBetTypeWinLoss(1, "BetType 1", true);
            var site2Live = CreateFakeRawBetTypeWinLoss(2, "BetType 2", true);
            var site1NonLive = CreateFakeRawBetTypeWinLoss(1, "BetType 1", false);
            var site2NonLive = CreateFakeRawBetTypeWinLoss(2, "BetType 2", false);
            return (new List<List<CommonModels.RawWinLoss>> { site1Live, site2Live, site1NonLive, site2NonLive })
                    .SelectMany(l => l)
                    .ToList();
        }

        private List<CommonModels.RawWinLoss> CreateFakeRawBetTypeWinLoss(int groupId, string groupName, bool isLive)
        {
            var creditWinLoss = NumberGameWinLossFactory.CreateRawWinLoss(groupId, groupName, "Credit", isLive, 100, 110, 10, 500, 600, -100, 900, 1000);
            var depositWinLoss = NumberGameWinLossFactory.CreateRawWinLoss(groupId, groupName, "Deposit", isLive, 110, 120, 11, 550, 660, -110, 990, 1100);

            return new List<CommonModels.RawWinLoss> { creditWinLoss, depositWinLoss };
        }

        private List<CommonModels.SiteWinLossSummary> CreateExpectedListOfBetTypeWinLoss()
        {
            var site1 = CreateExpectedBetTypeWinLoss(1, "BetType 1");
            var site2 = CreateExpectedBetTypeWinLoss(2, "BetType 2");

            return new List<CommonModels.SiteWinLossSummary> { site1, site2 };
        }

        private CommonModels.SiteWinLossSummary CreateExpectedBetTypeWinLoss(int betTypeId, string betType)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(betTypeId, "Credit", 100, 110, 10, 500, 600, -100, 100, 100, 900, 1000, 500m / 900, 600m / 1000);
            var depositWinLoss = WinLossFactory.CreateWinLoss(betTypeId, "Deposit", 110, 120, 11, 550, 660, -110, 100, 100, 990, 1100, 550m / 990, 660m / 1100);
            var totalWinLoss = WinLossFactory.CreateWinLoss(betTypeId, betType, 210, 230, 21, 1050, 1260, -210, 100, 100, 1890, 2100, 1050m / 1890, 1260m / 2100);

            return new CommonModels.SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }

        private CommonModels.SiteWinLossSummary CreateExpectedGrandTotal()
        {
            return new CommonModels.SiteWinLossSummary
            {
                Credit = WinLossFactory.CreateWinLoss(1, "Credit", 200, 220, 20, 1000, 1200, -200, 100, 100, 1800, 2000, 1000m / 1800, 1200m / 2000),
                Deposit = WinLossFactory.CreateWinLoss(1, "Deposit", 220, 240, 22, 1100, 1320, -220, 100, 100, 1980, 2200, 1100m / 1980, 1320m / 2200),
                Total = WinLossFactory.CreateWinLoss(1, "Grand Total", 420, 460, 42, 2100, 2520, -420, 100, 100, 3780, 4200, 2100m / 3780, 2520m / 4200)
            };
        }

        private bool AreTwoNumberGameBetTypeWinLossSummaryEqual(WinLossModel first, WinLossModel second)
        {
            return Comparison.AreEqual(first.LiveGrandTotal, second.LiveGrandTotal)
                && Comparison.AreEqual(first.NonLiveGrandTotal, second.NonLiveGrandTotal)
                && Comparison.AreEqual(first.Live, second.Live)
                && Comparison.AreEqual(first.NonLive, second.NonLive);
        }
    }
}
