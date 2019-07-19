using System.Threading.Tasks;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.Filter;
using FilterAvailableDatabase = UniversalReports.PunterAnalysis.Filter.AvailableDatabase;
using FilterAvailableDateRange = UniversalReports.PunterAnalysis.Filter.AvailableDateRange;
using FilterProductSportBetType = UniversalReports.PunterAnalysis.Filter.ProductSportBetType;
using FilterSportsbookSportBetType = UniversalReports.PunterAnalysis.Filter.SportsbookSportBetType;
using FilterSportTypeLeague = UniversalReports.PunterAnalysis.Filter.SportTypeLeague;
using FilterUsernameSuggestion = UniversalReports.PunterAnalysis.Filter.UsernameSuggestion;

namespace UniversalReports.PunterAnalysis.UnitTests.Filter
{
    public class PunterAnalysisFilterControllerUnitTests
    {
        [Test]
        public async Task AvailableDatabase_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterJson = new FilterAvailableDatabase.HttpParameterJson();

            // Act
            var controller = new PunterAnalysisFilterController(mediator);
            await controller.AvailableDatabase(httpParameterJson);

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<FilterAvailableDatabase.HttpParameterJson>());
        }

        [Test]
        public async Task AvailableDateRange_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterJson = new FilterAvailableDateRange.HttpParameterJson();

            // Act
            var controller = new PunterAnalysisFilterController(mediator);
            await controller.AvailableDateRange(httpParameterJson);

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<FilterAvailableDateRange.HttpParameterJson>());
        }

        [Test]
        public async Task ProductSportBetType_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterJson = new FilterProductSportBetType.HttpParameterJson();

            // Act
            var controller = new PunterAnalysisFilterController(mediator);
            await controller.ProductSportBetType(httpParameterJson);

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<FilterProductSportBetType.HttpParameterJson>());
        }

        [Test]
        public async Task UsernameSuggestion_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterJson = new FilterUsernameSuggestion.HttpParameterJson();

            // Act
            var controller = new PunterAnalysisFilterController(mediator);
            await controller.UsernameSuggestion(httpParameterJson);

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<FilterUsernameSuggestion.HttpParameterJson>());
        }

        [Test]
        public async Task SportsbookSportBetType_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterJson = new FilterSportsbookSportBetType.HttpParameterJson();

            // Act
            var controller = new PunterAnalysisFilterController(mediator);
            await controller.SportsbookSportBetType(httpParameterJson);

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<FilterSportsbookSportBetType.HttpParameterJson>());
        }

        [Test]
        public async Task SportTypeLeague_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterJson = new FilterSportTypeLeague.HttpParameterJson();

            // Act
            var controller = new PunterAnalysisFilterController(mediator);
            await controller.SportTypeLeague(httpParameterJson);

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<FilterSportTypeLeague.HttpParameterJson>());
        }
    }
}