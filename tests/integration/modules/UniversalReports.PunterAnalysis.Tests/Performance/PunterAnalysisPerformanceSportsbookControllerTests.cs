using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PunterAnalysis.Performance;
using UniversalReports.PunterAnalysis.Performance.Summary;
using UniversalReports.PunterAnalysis.Performance.Summary.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;

namespace UniversalReports.PunterAnalysis.Tests.Performance
{
    public class PunterAnalysisSummaryControllerTests
    {
        [Test]
        public async Task Summary_MemoryRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            var repositoryWithNonEmptyMonthStatistics = CreateRepositoryWithNonEmptyMonthStatistics();
            var factory = new ApiControllerFactoryMethodAbsoluteRepository();
            var controller = factory.CreateController<PunterAnalysisPerformanceController>(repositoryWithNonEmptyMonthStatistics);
            var summaryHttpParameterJson = new SummaryHttpParameterJson
            {
                FromDate = new DateTime(2016, 1, 15),
                ToDate = new DateTime(2016, 12, 15),
            };

            // Act
            var httpActionResult = await controller.Summary(summaryHttpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<ViewModelJson>).Content;

            // Assert
            var viewModelJsonWithRightSummaryStatistic = CreateViewModelJsonWithRightSummaryStatistic();
            Assert.That(viewModelJson, IsDeeplyEqual.To(viewModelJsonWithRightSummaryStatistic));

            // Release
            factory.Dispose();
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
                Turnover = 200,
                Margin = 0.5m
            };

            var secondMonthStatistic = new MonthStatistic
            {
                Date = new DateTime(2016, 2, 1),
                BetCount = 2,
                WinLoss = 30,
                Turnover = 100,
                Margin = 0.3m
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