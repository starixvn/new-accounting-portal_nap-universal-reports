using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;
using commonModel = UniversalReports.CompanyWinLoss.Common.Models;
using commonService = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.Cockfighting.MatchDetail
{
    [TestFixture]
    public class RawWinLossServiceUnitTests
    {
        [Test]
        public void Query_BalanceUpSourceChooserReturnsTwoSources_DynamicRepositoryCallTwice()
        {
            // Arrange
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            var balanceUpSummationService = Substitute.For<BalanceUpSummationService>();

            var twoSources = CreateBalanceUpSources();
            var balanceUpSourceChooser = Substitute.For<commonService.BalanceUpSourceChooser>();
            balanceUpSourceChooser.Determine(DateTime.Today, DateTime.Today).Returns(twoSources);

            var service = new RawWinLossServiceImp(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);

            // Act
            var criteria = new FakeWinLossCriteria { StartDate = DateTime.Today, EndDate = DateTime.Today };
            service.Query(criteria);

            // Assert
            dynamicRepository.Received(2).Fetch<RawWinLoss>(Arg.Any<WinLossCriteria>());
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
            var balanceUpSummationService = Substitute.For<BalanceUpSummationService>();

            var sources = CreateBalanceUpSources();
            var balanceUpSourceChooser = Substitute.For<commonService.BalanceUpSourceChooser>();
            balanceUpSourceChooser.Determine(DateTime.Today, DateTime.Today).Returns(sources);

            var service = Substitute.ForPartsOf<RawWinLossServiceImp>(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);
            var fakeWinLoss = CreateFakeRawWinLosses();
            service.QueryBySource(Arg.Any<CompanyWinLoss.Common.Models.BalanceUpSource>(), Arg.Any<WinLossCriteria>()).Returns(fakeWinLoss);

            // Act
            var criteria = new FakeWinLossCriteria { StartDate = DateTime.Today, EndDate = DateTime.Today };
            service.Query(criteria);

            // Assert
            balanceUpSummationService.Received().CalculateSum(Arg.Is<IEnumerable<IEnumerable<RawWinLoss>>>(x => x.Count() == 2));
        }

        private List<RawWinLoss> CreateFakeRawWinLosses()
        {
            var match1 = WinLossFactory.CreateRawWinLoss("match1", 1, "Home1", "Away1", 100, 110, 10, 500, 900);
            var match2 = WinLossFactory.CreateRawWinLoss("match2", 2, "Home2", "Away2", 110, 120, 11, 550, 990);

            return new List<RawWinLoss> { match1, match2 };
        }
    }
}
