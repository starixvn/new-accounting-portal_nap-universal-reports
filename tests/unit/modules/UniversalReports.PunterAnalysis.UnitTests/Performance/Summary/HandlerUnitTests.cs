using AutoMapper;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Performance.Summary;
using UniversalReports.PunterAnalysis.Performance.Summary.Criteria;
using UniversalReports.PunterAnalysis.Performance.Summary.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.Performance.Summary
{
    public class HandlerUnitTests
    {
        [Test]
        public async Task Handle_RepositoryReturnsEmptyData_ShouldReturnEmptyViewModelJson()
        {
            // Arrange
            var mapper = CreateMapper();
            var repositoryWithEmptyData = CreateRepositoryWithEmptyData();

            var handler = new Handler(mapper, repositoryWithEmptyData);

            // Act
            var viewModel = await handler.Handle(new SummaryHttpParameterJson());

            // Assert
            var expected = CreateEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SummaryHttpParameterJson, MonthCriteria>(MemberList.Source);
                cfg.CreateMap<SummaryHttpParameterJson, ProductTurnoverCriteria>(MemberList.Source);
                cfg.CreateMap<SummaryHttpParameterJson, SportCriteria>(MemberList.Source);
                cfg.CreateMap<SummaryHttpParameterJson, BetTypeCriteria>(MemberList.Source);
                cfg.CreateMap<SummaryHttpParameterJson, EventCriteria>(MemberList.Source);
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }

        private IDynamicRepository CreateRepositoryWithEmptyData()
        {
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<MonthStatistic>(Arg.Any<ICriteria>()).Returns(new List<MonthStatistic>());
            repository.FetchAsync<ProductTurnoverStatistic>(Arg.Any<ICriteria>()).Returns(new List<ProductTurnoverStatistic>());
            repository.FetchAsync<SportStatistic>(Arg.Any<ICriteria>()).Returns(new List<SportStatistic>());
            repository.FetchAsync<BetTypeStatistic>(Arg.Any<ICriteria>()).Returns(new List<BetTypeStatistic>());
            repository.FetchAsync<EventStatistic>(Arg.Any<ICriteria>()).Returns(new List<EventStatistic>());

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
            var mapper = CreateMapper();
            var repositoryWithNonEmptyMonthStatistics = CreateRepositoryWithNonEmptyMonthStatistics();

            // Act
            var handler = new Handler(mapper, repositoryWithNonEmptyMonthStatistics);
            var viewModel = await handler.Handle(new SummaryHttpParameterJson());

            // Assert
            var expected = CreateViewModelJsonWithRightSummaryStatistic();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private IDynamicRepository CreateRepositoryWithNonEmptyMonthStatistics()
        {
            var monthStatistics = CreateMonthStatistics();
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<MonthStatistic>(Arg.Any<ICriteria>()).Returns(monthStatistics);
            repository.FetchAsync<ProductTurnoverStatistic>(Arg.Any<ICriteria>()).Returns(new List<ProductTurnoverStatistic>());
            repository.FetchAsync<SportStatistic>(Arg.Any<ICriteria>()).Returns(new List<SportStatistic>());
            repository.FetchAsync<BetTypeStatistic>(Arg.Any<ICriteria>()).Returns(new List<BetTypeStatistic>());
            repository.FetchAsync<EventStatistic>(Arg.Any<ICriteria>()).Returns(new List<EventStatistic>());

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

        private ViewModelJson CreateViewModelJsonWithRightSummaryStatistic()
        {
            return new ViewModelJson
            {
                SummaryStatistic = new SummaryStatistic { BetCount = 3, Turnover = 300, WinLoss = 130 },
                MonthStatistics = CreateMonthStatistics(),
                ProductTurnoverStatistics = new List<ProductTurnoverStatistic>(),
                SportStatistics = new List<SportStatistic>(),
                BetTypeStatistics = new List<BetTypeStatistic>(),
                EventStatistics = new List<EventStatistic>()
            };
        }
    }
}
