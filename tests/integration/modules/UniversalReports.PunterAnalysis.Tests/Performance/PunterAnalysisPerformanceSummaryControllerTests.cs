using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PunterAnalysis.Performance;
using UniversalReports.PunterAnalysis.Performance.Sportsbook;
using UniversalReports.PunterAnalysis.Performance.Sportsbook.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;

namespace UniversalReports.PunterAnalysis.Tests.Performance
{
    public class PunterAnalysisPerformanceSportsbookControllerTests
    {
        [Test]
        public async Task Sportsbook_MemoryRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            var repositoryWithNonEmptySportStatistics = CreateRepositoryWithNonEmptySportStatistics();
            var factory = new ApiControllerFactoryMethodAbsoluteRepository();
            var controller = factory.CreateController<PunterAnalysisPerformanceController>(repositoryWithNonEmptySportStatistics);
            var httpParameterJson = new SportsbookHttpParameterJson
            {
                FromDate = new DateTime(2016, 1, 15),
                ToDate = new DateTime(2016, 12, 15),
            };

            // Act
            var httpActionResult = await controller.Sportsbook(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<ViewModelJson>).Content;

            // Assert
            var viewModelJsonWithRightSportsbookStatistic = CreateViewModelJsonWithRightSportsbookStatistic();
            Assert.That(viewModelJson, IsDeeplyEqual.To(viewModelJsonWithRightSportsbookStatistic));

            // Release
            factory.Dispose();
        }

        private IDynamicRepository CreateRepositoryWithNonEmptySportStatistics()
        {
            var sportStatistics = CreateSportStatistics();
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<SportStatistic>(Arg.Any<ICriteria>()).Returns(sportStatistics);
            repository.FetchAsync<BetCountStatistic>(Arg.Any<ICriteria>()).Returns(new List<BetCountStatistic>());

            return repository;
        }

        private List<SportStatistic> CreateSportStatistics()
        {
            var firstSportStatistic = new SportStatistic
            {
                SportName = "Sport 1",
                BetCount = 1,
                WinLoss = 100,
                Turnover = 200,
                Margin = 0.5m
            };

            var secondSportStatistic = new SportStatistic
            {
                SportName = "Sport 2",
                BetCount = 2,
                WinLoss = 30,
                Turnover = 100,
                Margin = 0.3m
            };

            return new List<SportStatistic> { firstSportStatistic, secondSportStatistic };
        }

        private ViewModelJson CreateViewModelJsonWithRightSportsbookStatistic()
        {
            return new ViewModelJson
            {
                SummaryStatistic = new SummaryStatistic { BetCount = 3, Turnover = 300, WinLoss = 130 },
                SportStatistics = CreateSportStatistics(),
                BetCountStatistics = new List<BetCountStatistic>()
            };
        }
    }
}