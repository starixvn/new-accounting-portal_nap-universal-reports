using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;
using commonModel = UniversalReports.CompanyWinLoss.Common.Models;
using commonService = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.MatchDetailServices
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
            var balanceUpSummationService = Substitute.For<MatchDetailBalanceUpSummationService>();

            var twoSources = CreateBalanceUpSources();
            var balanceUpSourceChooser = Substitute.For<commonService.BalanceUpSourceChooser>();
            balanceUpSourceChooser.Determine(DateTime.Today, DateTime.Today).Returns(twoSources);

            var service = new MatchDetailRawWinLossServiceImp(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);

            // Act
            var criteria = new FakeWinLossCriteria { StartDate = DateTime.Today, EndDate = DateTime.Today };
            service.Query(criteria);

            // Assert
            dynamicRepository.Received(2).Fetch<MatchDetailRawWinLoss>(Arg.Any<WinLossCriteria>());
        }

        private IEnumerable<commonModel.BalanceUpSource> CreateBalanceUpSources()
        {
            return new List<commonModel.BalanceUpSource>
            {
                CreateBalanceUpSource(1, 5, "BetTrans14"),
                CreateBalanceUpSource(6, 8, "BetTrans")
            };
        }

        private commonModel.BalanceUpSource CreateBalanceUpSource(int dayStart, int dayEnd, string source)
        {
            return new commonModel.BalanceUpSource
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
            var balanceUpSummationService = Substitute.For<MatchDetailBalanceUpSummationService>();

            var sources = CreateBalanceUpSources();
            var balanceUpSourceChooser = Substitute.For<commonService.BalanceUpSourceChooser>();
            balanceUpSourceChooser.Determine(DateTime.Today, DateTime.Today).Returns(sources);

            var service = Substitute.ForPartsOf<MatchDetailRawWinLossServiceImp>(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);
            var fakeWinLoss = CreateFakeRawWinLosses();
            service.QueryBySource(Arg.Any<CompanyWinLoss.Common.Models.BalanceUpSource>(), Arg.Any<WinLossCriteria>()).Returns(fakeWinLoss);

            // Act
            var criteria = new FakeWinLossCriteria { StartDate = DateTime.Today, EndDate = DateTime.Today };
            service.Query(criteria);

            // Assert
            balanceUpSummationService.Received().CalculateSum(Arg.Is<IEnumerable<IEnumerable<MatchDetailRawWinLoss>>>(x => x.Count() == 2));
        }

        private List<MatchDetailRawWinLoss> CreateFakeRawWinLosses()
        {
            var match1 = WinLossFactory.CreateRawWinLoss(1, 1, 1, 100, 10, 200, 400);
            var match2 = WinLossFactory.CreateRawWinLoss(2, 2, 2, 200, 20, 400, 800);

            return new List<MatchDetailRawWinLoss> { match1, match2 };
        }
    }
}
