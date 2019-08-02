using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.Performance.Summary;
using UniversalReports.PunterAnalysis.Performance.Summary.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.Performance.Summary
{
    public class HandlerUnitTests
    {
        [Test]
        public async Task Handle_RepositoryReturnsEmptyData_ShouldReturnEmptyViewModelJson()
        {
            // Arrange
            var repositoryWithEmptyData = CreateRepositoryWithEmptyData();

            var handler = new Handler(repositoryWithEmptyData);

            // Act
            var viewModel = await handler.Handle(new SummaryHttpParameterJson(), new CancellationToken());

            // Assert
            var expected = CreateEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private IDynamicRepository CreateRepositoryWithEmptyData()
        {
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<MonthStatistic>(Arg.Compat.Any<ICriteria>()).Returns(new List<MonthStatistic>());
            repository.FetchAsync<ProductTurnoverStatistic>(Arg.Compat.Any<ICriteria>()).Returns(new List<ProductTurnoverStatistic>());
            repository.FetchAsync<SportStatistic>(Arg.Compat.Any<ICriteria>()).Returns(new List<SportStatistic>());
            repository.FetchAsync<BetTypeStatistic>(Arg.Compat.Any<ICriteria>()).Returns(new List<BetTypeStatistic>());
            repository.FetchAsync<EventStatistic>(Arg.Compat.Any<ICriteria>()).Returns(new List<EventStatistic>());

            return repository;
        }

        private ViewModelJson CreateEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                SummaryStatistic = new SummaryStatistic { BetCount = 0, Turnover = 0, WinLoss = 0 },
                MonthStatistics = new List<MonthStatistic>(),
                ProductTurnoverStatistics = new List<ProductTurnoverStatistic>(),
                SportStatistics = new List<SportStatistic>(),
                BetTypeStatistics = new List<BetTypeStatistic>(),
                EventStatistics = new List<EventStatistic>()
            };
        }

        [Test]
        public async Task Handle_RepositoryReturnsNonEmptyData_ShouldReturnViewModelJsonWithRightSummaryStatistic()
        {
            // Arrange
            var repositoryWithNonEmptyMonthStatistics = CreateRepositoryWithNonEmptyStatistics();

            // Act
            var handler = new Handler(repositoryWithNonEmptyMonthStatistics);
            var viewModel = await handler.Handle(new SummaryHttpParameterJson(), new CancellationToken());

            // Assert
            var expected = CreateViewModelJsonWithRightSummaryStatistic();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private IDynamicRepository CreateRepositoryWithNonEmptyStatistics()
        {
            var monthStatistics = CreateMonthStatistics();
            var sportStatistics = CreateSportStatistics();
            var productTurnoverStatistics = CreateProductTurnoverStatistics();
            var eventStatistics = CreateEventStatistics();
            var betTypeStatistics = CreateBetTypeStatistics();
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<MonthStatistic>(Arg.Compat.Any<ICriteria>()).Returns(monthStatistics);
            repository.FetchAsync<ProductTurnoverStatistic>(Arg.Compat.Any<ICriteria>()).Returns(productTurnoverStatistics);
            repository.FetchAsync<SportStatistic>(Arg.Compat.Any<ICriteria>()).Returns(sportStatistics);
            repository.FetchAsync<BetTypeStatistic>(Arg.Compat.Any<ICriteria>()).Returns(betTypeStatistics);
            repository.FetchAsync<EventStatistic>(Arg.Compat.Any<ICriteria>()).Returns(eventStatistics);

            return repository;
        }

        private List<MonthStatistic> CreateMonthStatistics()
        {
            var firstMonthStatistic = new MonthStatistic
            {
                Date = new DateTime(2016, 1, 1),
                BetCount = 1,
                WinLoss = 100,
                Turnover = 200
            };

            var secondMonthStatistic = new MonthStatistic
            {
                Date = new DateTime(2016, 2, 1),
                BetCount = 2,
                WinLoss = 30,
                Turnover = 100
            };

            return new List<MonthStatistic> { firstMonthStatistic, secondMonthStatistic };
        }

        private List<SportStatistic> CreateSportStatistics()
        {
            var sportStatistic = new SportStatistic
            {
                BetCount = 1,
                Margin = 0.5m,
                SportName = "Soccer",
                Turnover = 100,
                WinLoss = 100
            };

            return new List<SportStatistic>
            {
                sportStatistic
            };
        }

        private List<ProductTurnoverStatistic> CreateProductTurnoverStatistics()
        {
            var productTurnoverStatistic = new ProductTurnoverStatistic
            {
                ProductName = "Sportsbook",
                Turnover = 100m
            };

            return new List<ProductTurnoverStatistic>
            {
                productTurnoverStatistic
            };
        }

        private List<EventStatistic> CreateEventStatistics()
        {
            var eventStatistic = new EventStatistic
            {
                EventType = "Event",
                WinLoss = 100m,
                Margin = 0.5m,
                BetCount = 1,
                Turnover = 100m
            };

            return new List<EventStatistic>
            {
                eventStatistic
            };
        }

        private List<BetTypeStatistic> CreateBetTypeStatistics()
        {
            var betTypeStatistic = new BetTypeStatistic
            {
                BetTypeName = "BetType",
                WinLoss = 100m,
                Margin = 0.5m,
                BetCount = 1,
                Turnover = 100m
            };

            return new List<BetTypeStatistic>
            {
                betTypeStatistic
            };
        }

        private ViewModelJson CreateViewModelJsonWithRightSummaryStatistic()
        {
            return new ViewModelJson
            {
                SummaryStatistic = new SummaryStatistic { BetCount = 3, Turnover = 300, WinLoss = 130 },
                MonthStatistics = CreateMonthStatistics(),
                ProductTurnoverStatistics = CreateProductTurnoverStatistics(),
                SportStatistics = CreateSportStatistics(),
                BetTypeStatistics = CreateBetTypeStatistics(),
                EventStatistics = CreateEventStatistics()
            };
        }
    }
}