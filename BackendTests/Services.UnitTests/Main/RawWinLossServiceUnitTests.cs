using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.QueryModels.Main;
using NAP.Reports.CompanyWinLoss.Services.Main;
using NAP.Reports.CompanyWinLoss.Services.Models;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests.Main
{
    public class RawWinLossServiceUnitTests
    {
        [Test]
        [Category("ServiceUnitTests")]
        public void Query_BalanceUpSourceChooserReturnsTwoSources_DynamicRepositoryCallTwice()
        {
            // Arrange
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            var calculationService = Substitute.For<ICalculationService>();

            var twoSources = CreateBalanceUpSources();
            var balanceUpSourceChooser = Substitute.For<IBalanceUpSourceChooser>();
            balanceUpSourceChooser.Determine(DateTime.Today, DateTime.Today).Returns(twoSources);

            var service = new RawWinLossService(dynamicRepository, calculationService, balanceUpSourceChooser);

            // Act
            var query = new MainQuery { StartDate = DateTime.Today, EndDate = DateTime.Today };
            var result = service.Query(query);

            // Assert
            dynamicRepository.Received(2).Fetch<RawWinLoss>(Arg.Any<WinLossCriteria>());
        }

        private List<BalanceUpSource> CreateBalanceUpSources()
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
        [Category("ServiceUnitTests")]
        public void Query_TwoSources_CallCalculationServiceWithTwoDimensionArray()
        {
            // Arrange
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            var calculationService = Substitute.For<ICalculationService>();

            var sources = CreateBalanceUpSources();
            var balanceUpSourceChooser = Substitute.For<IBalanceUpSourceChooser>();
            balanceUpSourceChooser.Determine(DateTime.Today, DateTime.Today).Returns(sources);

            var service = Substitute.ForPartsOf<RawWinLossService>(dynamicRepository, calculationService, balanceUpSourceChooser);
            var fakeWinLoss = CreateFakeRawWinLosses();
            service.QueryBySource(Arg.Any<BalanceUpSource>()).Returns(fakeWinLoss);

            // Act
            var query = new MainQuery { StartDate = DateTime.Today, EndDate = DateTime.Today };
            var result = service.Query(query);

            // Assert
            calculationService.Received().CalculateSum(Arg.Is<IEnumerable<IEnumerable<RawWinLoss>>>(x => x.Count() == 2));
        }

        private List<RawWinLoss> CreateFakeRawWinLosses()
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss("Number Game", "Credit", 100, 200, 10, 300, 400, 1000, 1200);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss("Number Game", "Deposit", 110, 210, 20, 310, 410, 1100, 1300);

            return new List<RawWinLoss> { creditWinLoss, depositWinLoss };
        }
    }
}
