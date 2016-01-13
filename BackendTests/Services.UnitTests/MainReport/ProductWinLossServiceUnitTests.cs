using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services.MainReport;
using NAP.Reports.CompanyWinLoss.Services.Models;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests.MainReport
{
    public class ServiceUnitTests
    {
        private const string NumberGame = "Number Game";

        [Test]
        [Category("ServiceUnitTests")]
        public void QueryBySource_NumberGame_DynamicRepositoryReturnsFullData_Calls_CalculationService_FromRawWinLoss()
        {
            // Arrange
            var expectedData = CreateExpectedProductWinLoss();
            var fakeData = CreateFakeRawWinLosses();

            var dynamicRepository = Substitute.For<IDynamicRepository>();
            dynamicRepository.Fetch<RawWinLoss>(Arg.Any<ICriteria>()).Returns(fakeData);

            var calculationService = Substitute.For<ICalculationService>();
            var balanceUpSourceChooser = Substitute.For<IBalanceUpSourceChooser>();

            var service = new ProductWinLossService(dynamicRepository, calculationService, balanceUpSourceChooser);

            // Act
            var balanceUpSource = CreateBalanceUpSource(1, 5, "BetTrans");
            var result = service.QueryBySource(NumberGame, balanceUpSource);

            // Assert
            calculationService.Received(2).FromRawWinLoss(Arg.Any<RawWinLoss>());
        }

        private ProductWinLoss CreateExpectedProductWinLoss()
        {
            return new ProductWinLoss
            {
                Credit = WinLossFactory.CreateWinLoss("Credit", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000, 400m / 1200),
                Deposit = WinLossFactory.CreateWinLoss("Deposit", 110, 210, 20, 310, 410, -100, 1100, 1300, 310.0m / 1100, 410.0m / 1300),
                Total = WinLossFactory.CreateWinLoss(NumberGame, 210, 410, 30, 610, 810, -200, 2100, 2500, 610.0m / 2100, 810.0m / 2500)
            };
        }

        private List<RawWinLoss> CreateFakeRawWinLosses()
        {
            var creditWinLoss = WinLossFactory.CreateRawWinLoss("Credit", 100, 200, 10, 300, 400, 1000, 1200);
            var depositWinLoss = WinLossFactory.CreateRawWinLoss("Deposit", 110, 210, 20, 310, 410, 1100, 1300);

            return new List<RawWinLoss> { creditWinLoss, depositWinLoss };
        }

        [Test]
        [Category("ServiceUnitTests")]
        public void QueryBySource_NumberGame_MissingCreditAndDeposit_Calls_CalculationService_CreateEmptyWinLoss()
        {
            // Arrange
            var expectedData = CreateEmptyProductWinLoss(NumberGame);
            var fakeData = new List<RawWinLoss>();

            var dynamicRepository = Substitute.For<IDynamicRepository>();
            dynamicRepository.Fetch<RawWinLoss>(Arg.Any<ICriteria>()).Returns(fakeData);

            var calculationService = Substitute.For<ICalculationService>();
            var balanceUpSourceChooser = Substitute.For<IBalanceUpSourceChooser>();

            var service = new ProductWinLossService(dynamicRepository, calculationService, balanceUpSourceChooser);

            // Act
            var balanceUpSource = CreateBalanceUpSource(1, 5, "BetTrans");
            var result = service.QueryBySource(NumberGame, balanceUpSource);

            // Assert
            calculationService.Received(2).CreateEmptyWinLoss(Arg.Any<string>());
        }

        private ProductWinLoss CreateEmptyProductWinLoss(string productName)
        {
            return new ProductWinLoss
            {
                Credit = WinLossFactory.CreateWinLoss("Credit", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                Deposit = WinLossFactory.CreateWinLoss("Deposit", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                Total = WinLossFactory.CreateWinLoss(productName, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
            };
        }

        [Test]
        [Category("ServiceUnitTests")]
        public void Query_BalanceUpSourceChooserReturnsTwoSources_DynamicRepositoryCallTwice()
        {
            // Arrange
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            var calculationService = Substitute.For<ICalculationService>();

            var twoSources = CreateBalanceUpSources();
            var balanceUpSourceChooser = Substitute.For<IBalanceUpSourceChooser>();
            balanceUpSourceChooser.Determine(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(twoSources);

            var service = new ProductWinLossService(dynamicRepository, calculationService, balanceUpSourceChooser);

            // Act
            var query = new MainReportQuery();
            var result = service.Query(NumberGame, query);

            // Assert
            dynamicRepository.Received(2).Fetch<RawWinLoss>(Arg.Any<ProductWinLossCriteria>());
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
    }
}
