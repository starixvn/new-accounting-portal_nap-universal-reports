using System;
using System.Collections.Generic;
using System.Linq;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common
{
    public class RawWinLossServiceUnitTests
    {
        [Test]
        public void Query_BalanceUpSourceChooserReturnsTwoSources_DynamicRepositoryCallTwice()
        {
            // Arrange
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            var balanceUpSummationService = Substitute.For<BalanceUpSummationService>();

            var twoSources = CreateBalanceUpSources();
            var balanceUpSourceChooser = Substitute.For<BalanceUpSourceChooser>();
            balanceUpSourceChooser.Determine(DateTime.Today, DateTime.Today).Returns(twoSources);

            var service = new RawWinLossServiceImp(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);

            // Act
            var criteria = new FakeWinLossCriteria { StartDate = DateTime.Today, EndDate = DateTime.Today };
            service.Query(criteria);

            // Assert
            dynamicRepository.Received(2).Fetch<RawWinLoss>(Arg.Any<WinLossCriteria>());
        }

        private IEnumerable<BalanceUpSource> CreateBalanceUpSources()
        {
            return new List<BalanceUpSource>
            {
                CreateBalanceUpSource(1, 5, "BetTrans14"),
                CreateBalanceUpSource(6, 8, "BetTrans")
            };
        }

        private BalanceUpSource CreateBalanceUpSource(int dayStart, int dayEnd, string source)
        {
            return new BalanceUpSource
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
            var balanceUpSourceChooser = Substitute.For<BalanceUpSourceChooser>();
            balanceUpSourceChooser.Determine(DateTime.Today, DateTime.Today).Returns(sources);

            var service = Substitute.ForPartsOf<RawWinLossServiceImp>(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);
            var fakeWinLoss = CreateFakeRawWinLosses();
            service.QueryBySource(Arg.Any<BalanceUpSource>(), Arg.Any<WinLossCriteria>()).Returns(fakeWinLoss);

            // Act
            var criteria = new FakeWinLossCriteria { StartDate = DateTime.Today, EndDate = DateTime.Today };
            service.Query(criteria);

            // Assert
            balanceUpSummationService.Received().CalculateSum(Arg.Is<IEnumerable<IEnumerable<RawWinLoss>>>(x => x.Count() == 2));
        }

        private List<RawWinLoss> CreateFakeRawWinLosses()
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss(1, "Group 1", "Credit", 100, 110, 10, 500, 600, 900, 1000);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss(1, "Group 1", "Deposit", 110, 120, 11, 550, 660, 990, 1100);

            return new List<RawWinLoss> { creditWinLoss, depositWinLoss };
        }
    }
}
