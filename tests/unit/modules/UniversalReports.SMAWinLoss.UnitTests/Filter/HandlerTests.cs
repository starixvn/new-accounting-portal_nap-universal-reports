using AutoFixture;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.SMAWinLoss.Filter;

namespace UniversalReports.SMAWinLoss.UnitTests.Filter
{
    [TestFixture]
    [Category("SMAWinLoss")]
    public class HandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightSite()
        {
            // Arrange
            var sites = fixture.Create<IEnumerable<Site>>();

            var service = Substitute.For<FilterService>();
            service.GetSites().Returns(sites);

            var handler = new Handler(service);

            // Act
            var model = await handler.Handle(new SiteHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(sites));
        }

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightSport()
        {
            // Arrange
            var sports = fixture.Create<IEnumerable<Sport>>();

            var service = Substitute.For<FilterService>();
            service.GetSports().Returns(sports);

            var handler = new Handler(service);

            // Act
            var model = await handler.Handle(new SportHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(sports));
        }

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightCurrency()
        {
            // Arrange
            var currencies = fixture.Create<IEnumerable<Currency>>();

            var service = Substitute.For<FilterService>();
            service.GetCurrencies().Returns(currencies);

            var handler = new Handler(service);

            // Act
            var model = await handler.Handle(new CurrencyHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(currencies));
        }

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightLeagueGroup()
        {
            // Arrange
            var leagueGroups = fixture.Create<IEnumerable<LeagueGroup>>();

            var service = Substitute.For<FilterService>();
            service.GetLeagueGroup().Returns(leagueGroups);

            var handler = new Handler(service);

            // Act
            var model = await handler.Handle(new LeagueGroupHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(leagueGroups));
        }

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightAvalableDatabase()
        {
            // Arrange
            var availableDatabase = fixture.Create<bool>();

            var service = Substitute.For<FilterService>();
            service.GetAvailableDatabase().Returns(availableDatabase);

            var handler = new Handler(service);

            // Act
            var model = await handler.Handle(new AvailableDatabaseHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(availableDatabase));
        }

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightAvalableDateData()
        {
            // Arrange
            var availableDateData = fixture.Create<string>();

            var service = Substitute.For<FilterService>();
            service.GetAvailableDateData().Returns(availableDateData);

            var handler = new Handler(service);

            // Act
            var model = await handler.Handle(new AvailableDateDataHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(availableDateData));
        }
    }
}