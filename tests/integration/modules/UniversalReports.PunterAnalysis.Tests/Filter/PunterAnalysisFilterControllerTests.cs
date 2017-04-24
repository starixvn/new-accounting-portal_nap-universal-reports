using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PunterAnalysis.Filter;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;
using AvailableDatabaseFilter = UniversalReports.PunterAnalysis.Filter.AvailableDatabase;
using AvailableDateRangeFilter = UniversalReports.PunterAnalysis.Filter.AvailableDateRange;
using LeagueFilter = UniversalReports.PunterAnalysis.Filter.League;
using ProductSportBetTypeFilter = UniversalReports.PunterAnalysis.Filter.ProductSportBetType;
using SportsbookSportBetTypeFilter = UniversalReports.PunterAnalysis.Filter.SportsbookSportBetType;
using SportTypeLeagueFilter = UniversalReports.PunterAnalysis.Filter.SportTypeLeague;
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
            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PunterAnalysisFilterController, ProductSportBetTypeFilter.ProductSportBetTypeEntity>(FakeRepositoryDataFileName);

            // Act
            var httpParameterJson = new ProductSportBetTypeFilter.HttpParameterJson();
            var httpActionResult = await controller.ProductSportBetType(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<IEnumerable<ProductSportBetTypeFilter.ProductSportBetTypeEntity>>).Content;

            // Assert
            Assert.That(viewModelJson, Has.Count.GreaterThan(0));

            // Release
            factory.Dispose();
        }

        [Test]
        public async Task League_FileRepository_ReturnsNonEmptyListOfLeague()
        {
            // Arrange
            const string FakeRepositoryDataFileName = "Filter-League-FileRepository.json";
            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PunterAnalysisFilterController, LeagueFilter.LeagueEntity>(FakeRepositoryDataFileName);

            // Act
            var httpParameterJson = new LeagueFilter.HttpParameterJson();
            var httpActionResult = await controller.League(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<IEnumerable<LeagueFilter.LeagueEntity>>).Content;

            // Assert
            Assert.That(viewModelJson, Has.Count.GreaterThan(0));

            // Release
            factory.Dispose();
        }

        [Test]
        public async Task AvailableDatabase_RepositoryReturnsTrue_ReturnsTrue()
        {
            // Arrange
            var repository = Substitute.For<IDynamicRepository>();
            repository.GetAsync<bool>(Arg.Any<ICriteria>()).Returns(true);
            var factory = new ApiControllerFactoryMethodAbsoluteRepository();
            var controller = factory.CreateController<PunterAnalysisFilterController>(repository);

            // Act
            var httpParameterJson = new AvailableDatabaseFilter.HttpParameterJson();
            var httpActionResult = await controller.AvailableDatabase(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<bool>).Content;

            // Assert
            Assert.True(viewModelJson);

            // Release
            factory.Dispose();
        }

        [Test]
        public async Task AvailableDateRange_RepositoryReturnsNonNullRange_ReturnsNonNullRange()
        {
            // Arrange
            var nonNullRange = new AvailableDateRangeFilter.DateRange { MinDate = DateTime.MaxValue, MaxDate = DateTime.MaxValue };
            var repository = Substitute.For<IDynamicRepository>();
            repository.GetAsync<AvailableDateRangeFilter.DateRange>(Arg.Any<ICriteria>()).Returns(nonNullRange);
            var factory = new ApiControllerFactoryMethodAbsoluteRepository();
            var controller = factory.CreateController<PunterAnalysisFilterController>(repository);

            // Act
            var httpParameterJson = new AvailableDateRangeFilter.HttpParameterJson();
            var httpActionResult = await controller.AvailableDateRange(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<AvailableDateRangeFilter.DateRange>).Content;

            // Assert
            Assert.That(viewModelJson.MinDate, Is.GreaterThan(DateTime.MinValue));
            Assert.That(viewModelJson.MaxDate, Is.GreaterThan(DateTime.MinValue));

            // Release
            factory.Dispose();
        }

        [Test]
        public async Task UsernameSuggestion_RepositoryReturnsNonEmptyListOfUsername_ReturnsNonEmptyListOfUsername()
        {
            // Arrange
            var nonEmptyListOfUsername = new List<string> { "Username 1", "Username 2" };
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<string>(Arg.Any<ICriteria>()).Returns(nonEmptyListOfUsername);
            var factory = new ApiControllerFactoryMethodAbsoluteRepository();
            var controller = factory.CreateController<PunterAnalysisFilterController>(repository);

            // Act
            var httpParameterJson = new UsernameSuggestionFilter.HttpParameterJson();
            var httpActionResult = await controller.UsernameSuggestion(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<IEnumerable<string>>).Content;

            // Assert
            Assert.That(viewModelJson, Has.Count.GreaterThan(0));

            // Release
            factory.Dispose();
        }

        [Test]
        public async Task SportsbookSportBetType_FileRepository_ReturnsNonEmptyListOfSportsbookSportBetType()
        {
            // Arrange
            const string FakeRepositoryDataFileName = "Filter-SportsbookSportBetType-FileRepository.json";
            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PunterAnalysisFilterController, SportsbookSportBetTypeFilter.SportsbookSportBetTypeEntity>(FakeRepositoryDataFileName);

            // Act
            var httpParameterJson = new SportsbookSportBetTypeFilter.HttpParameterJson();
            var httpActionResult = await controller.SportsbookSportBetType(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<IEnumerable<SportsbookSportBetTypeFilter.SportsbookSportBetTypeEntity>>).Content;

            // Assert
            Assert.That(viewModelJson, Has.Count.GreaterThan(0));

            // Release
            factory.Dispose();
        }

        [Test]
        public async Task SportTypeLeague_FileRepository_ReturnsNonEmptyListOfSportTypeLeague()
        {
            // Arrange
            const string FakeRepositoryDataFileName = "Filter-SportTypeLeague-FileRepository.json";
            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PunterAnalysisFilterController, SportTypeLeagueFilter.SportTypeLeagueEntity>(FakeRepositoryDataFileName);

            // Act
            var httpParameterJson = new SportTypeLeagueFilter.HttpParameterJson { SportId = 1 };
            var httpActionResult = await controller.SportTypeLeague(httpParameterJson);
            var viewModelJson = (httpActionResult as JsonResult<IEnumerable<SportTypeLeagueFilter.SportTypeLeagueEntity>>).Content;

            // Assert
            Assert.That(viewModelJson, Has.Count.GreaterThan(0));

            // Release
            factory.Dispose();
        }
    }
}