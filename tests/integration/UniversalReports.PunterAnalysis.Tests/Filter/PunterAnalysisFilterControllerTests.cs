using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.Filter;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;
using AvailableDatabaseFilter = UniversalReports.PunterAnalysis.Filter.AvailableDatabase;
using AvailableDateRangeFilter = UniversalReports.PunterAnalysis.Filter.AvailableDateRange;
using LeagueFilter = UniversalReports.PunterAnalysis.Filter.League;
using ProductSportBetTypeFilter = UniversalReports.PunterAnalysis.Filter.ProductSportBetType;
using UsernameSuggestionFilter = UniversalReports.PunterAnalysis.Filter.UsernameSuggestion;

namespace UniversalReports.PunterAnalysis.Tests.Filter
{
    public class PunterAnalysisFilterControllerTests
    {
        [Test]
        public async Task ProductSportBetType_FileRepository_ReturnsNonEmptyListOfProductSportBetType()
        {
            // Arrange
            const string FakeRepositoryDataFileName = "Filter-ProductSportBetType-FileRepository.json";

            var fakeProductSportBetTypeList = TestDataLoader.Load<List<ProductSportBetTypeFilter.Entity>>(FakeRepositoryDataFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<ProductSportBetTypeFilter.Entity>(Arg.Any<ICriteria>()).Returns(fakeProductSportBetTypeList);

            var simpleInjectorTest = new SimpleInjectorTest(repository);

            // Act
            var httpParameterJson = new ProductSportBetTypeFilter.HttpParameterJson();
            var controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisFilterController)) as PunterAnalysisFilterController;
            var httpActionResult = await controller.ProductSportBetType(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<IEnumerable<ProductSportBetTypeFilter.Entity>>).Content;

            // Assert
            Assert.That(viewModelJson, Has.Count.GreaterThan(0));
        }

        [Test]
        public async Task League_FileRepository_ReturnsNonEmptyListOfLeague()
        {
            // Arrange
            const string FakeRepositoryDataFileName = "Filter-League-FileRepository.json";

            var fakeLeagueList = TestDataLoader.Load<List<LeagueFilter.Entity>>(FakeRepositoryDataFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LeagueFilter.Entity>(Arg.Any<ICriteria>()).Returns(fakeLeagueList);

            var simpleInjectorTest = new SimpleInjectorTest(repository);

            // Act
            var httpParameterJson = new LeagueFilter.HttpParameterJson();
            var controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisFilterController)) as PunterAnalysisFilterController;
            var httpActionResult = await controller.League(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<IEnumerable<LeagueFilter.Entity>>).Content;

            // Assert
            Assert.That(viewModelJson, Has.Count.GreaterThan(0));
        }

        [Test]
        public async Task AvailableDatabase_RepositoryReturnsTrue_ReturnsTrue()
        {
            // Arrange
            var repository = Substitute.For<IDynamicRepository>();
            repository.GetAsync<bool>(Arg.Any<ICriteria>()).Returns(true);

            var simpleInjectorTest = new SimpleInjectorTest(repository);

            // Act
            var httpParameterJson = new AvailableDatabaseFilter.HttpParameterJson();
            var controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisFilterController)) as PunterAnalysisFilterController;
            var httpActionResult = await controller.AvailableDatabase(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<bool>).Content;

            // Assert
            Assert.True(viewModelJson);
        }

        [Test]
        public async Task AvailableDateRange_RepositoryReturnsNonNullRange_ReturnsNonNullRange()
        {
            // Arrange
            var nonNullRange = new AvailableDateRangeFilter.Entity { MinDate = DateTime.MaxValue, MaxDate = DateTime.MaxValue };
            var repository = Substitute.For<IDynamicRepository>();
            repository.GetAsync<AvailableDateRangeFilter.Entity>(Arg.Any<ICriteria>()).Returns(nonNullRange);

            var simpleInjectorTest = new SimpleInjectorTest(repository);

            // Act
            var httpParameterJson = new AvailableDateRangeFilter.HttpParameterJson();
            var controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisFilterController)) as PunterAnalysisFilterController;
            var httpActionResult = await controller.AvailableDateRange(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<AvailableDateRangeFilter.Entity>).Content;

            // Assert
            Assert.That(viewModelJson.MinDate, Is.GreaterThan(DateTime.MinValue));
            Assert.That(viewModelJson.MaxDate, Is.GreaterThan(DateTime.MinValue));
        }

        [Test]
        public async Task UsernameSuggestion_RepositoryReturnsNonEmptyListOfUsername_ReturnsNonEmptyListOfUsername()
        {
            // Arrange
            var nonEmptyListOfUsername = new List<string> { "Username 1", "Username 2" };
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<string>(Arg.Any<ICriteria>()).Returns(nonEmptyListOfUsername);

            var simpleInjectorTest = new SimpleInjectorTest(repository);

            // Act
            var httpParameterJson = new UsernameSuggestionFilter.HttpParameterJson();
            var controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisFilterController)) as PunterAnalysisFilterController;
            var httpActionResult = await controller.UsernameSuggestion(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<IEnumerable<string>>).Content;

            // Assert
            Assert.That(viewModelJson, Has.Count.GreaterThan(0));
        }
    }
}