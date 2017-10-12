using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.Performance.Sportsbook;
using UniversalReports.PunterAnalysis.Performance.Sportsbook.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.Performance.Sportsbook
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
            var viewModel = await handler.Handle(new SportsbookHttpParameterJson());

            // Assert
            var expected = CreateEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private IDynamicRepository CreateRepositoryWithEmptyData()
        {
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<BetCountStatistic>(Arg.Any<ICriteria>()).Returns(new List<BetCountStatistic>());
            repository.FetchAsync<SportStatistic>(Arg.Any<ICriteria>()).Returns(new List<SportStatistic>());

            return repository;
        }

        private ViewModelJson CreateEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                SummaryStatistic = new SummaryStatistic { BetCount = 0, Turnover = 0, WinLoss = 0 },
                SportStatistics = new List<SportStatistic>(),
            };
        }

        [Test]
        public async Task Handle_RepositoryReturnsNonEmptyData_ShouldReturnViewModelJsonWithRightSportsbookStatistic()
        {
            // Arrange
            var repositoryWithNonEmptySportStatistics = CreateRepositoryWithNonEmptySportStatistics();

            // Act
            var handler = new Handler(repositoryWithNonEmptySportStatistics);
            var viewModel = await handler.Handle(new SportsbookHttpParameterJson());

            // Assert
            var expected = CreateViewModelJsonWithRightSportsbookStatistic();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
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
                Turnover = 200
            };

            var secondSportStatistic = new SportStatistic
            {
                SportName = "Sport 2",
                BetCount = 2,
                WinLoss = 30,
                Turnover = 100
            };

            return new List<SportStatistic> { firstSportStatistic, secondSportStatistic };
        }

        private ViewModelJson CreateViewModelJsonWithRightSportsbookStatistic()
        {
            return new ViewModelJson
            {
                SummaryStatistic = new SummaryStatistic { BetCount = 3, Turnover = 300, WinLoss = 130 },
                SportStatistics = CreateSportStatistics(),
            };
        }
    }
}