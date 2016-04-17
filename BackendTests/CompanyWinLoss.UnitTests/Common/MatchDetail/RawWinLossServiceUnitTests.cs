using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetail;
using BalanceUp = UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using Utility = UniversalReports.CompanyWinLoss.UnitTests.TestUtility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class RawWinLossServiceUnitTests
    {
        [Test]
        public void Query_BalanceUpSourceChooserReturnsTwoSources_DynamicRepositoryCallTwice()
        {
            // Arrange
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            var balanceUpSummationService = Substitute.For<BalanceUpSummationService>();

            var twoSources = CreateBalanceUpSources();
            var balanceUpSourceChooser = Substitute.For<BalanceUp.BalanceUpSourceChooser>();
            balanceUpSourceChooser.Determine(DateTime.Today, DateTime.Today).Returns(twoSources);

            var service = new RawWinLossServiceImp(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);

            // Act
            var criteria = new Utility.FakeWinLossCriteria { StartDate = DateTime.Today, EndDate = DateTime.Today };
            service.Query(criteria);

            // Assert
            dynamicRepository.Received(2).Fetch<RawWinLoss>(Arg.Any<WinLossCriteria>());
        }

        private IEnumerable<BalanceUp.BalanceUpSource> CreateBalanceUpSources()
        {
            return new List<BalanceUp.BalanceUpSource>
            {
                CreateBalanceUpSource(1, 5, "BetTrans14"),
                CreateBalanceUpSource(6, 8, "BetTrans")
            };
        }

        private BalanceUp.BalanceUpSource CreateBalanceUpSource(int dayStart, int dayEnd, string source)
        {
            return new BalanceUp.BalanceUpSource
            {
                StartDate = new DateTime(2015, 01, dayStart),
                EndDate = new DateTime(2015, 01, dayEnd),
                Source = source
            };
        }

        [Test]
        public void Query_TwoSources_CallCalculationServiceWithTwoDimensionArray()
        {
            // Arrange
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            var balanceUpSummationService = Substitute.For<BalanceUpSummationService>();

            var sources = CreateBalanceUpSources();
            var balanceUpSourceChooser = Substitute.For<BalanceUp.BalanceUpSourceChooser>();
            balanceUpSourceChooser.Determine(DateTime.Today, DateTime.Today).Returns(sources);

            var service = Substitute.ForPartsOf<RawWinLossServiceImp>(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);
            var fakeWinLoss = CreateFakeRawWinLosses();
            service.QueryBySource(Arg.Any<BalanceUp.BalanceUpSource>(), Arg.Any<WinLossCriteria>()).Returns(fakeWinLoss);

            // Act
            var criteria = new Utility.FakeWinLossCriteria { StartDate = DateTime.Today, EndDate = DateTime.Today };
            service.Query(criteria);

            // Assert
            balanceUpSummationService.Received().CalculateSum(Arg.Is<IEnumerable<IEnumerable<RawWinLoss>>>(x => x.Count() == 2));
        }

        private List<RawWinLoss> CreateFakeRawWinLosses()
        {
            var match1 = WinLossFactory.CreateRawWinLoss(1, 1, 1, 100, 10, 200, 400);
            var match2 = WinLossFactory.CreateRawWinLoss(2, 2, 2, 200, 20, 400, 800);

            return new List<RawWinLoss> { match1, match2 };
        }
    }
}
