using AutoFixture;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Filter;
using UniversalReports.AbnormalBet.HttpParameter;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.UnitTests.Filter
{
    [TestFixture]
    [Category("AbnormalBet")]
    public class FilterHandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightSite()
        {
            // Arrange
            var sites = fixture.Create<IEnumerable<SiteModel>>();

            var service = Substitute.For<FilterService>();
            service.QuerySite().Returns(sites);

            var handler = new FilterHandler(service);

            // Act
            var model = await handler.Handle(new SiteHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(sites));
        }

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightReason()
        {
            // Arrange
            var reasons = fixture.Create<IEnumerable<FilterItemModel>>();

            var service = Substitute.For<FilterService>();
            service.QueryReason().Returns(reasons);

            var handler = new FilterHandler(service);

            // Act
            var model = await handler.Handle(new ReasonHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(reasons));
        }

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightSport()
        {
            // Arrange
            var sports = fixture.Create<IEnumerable<FilterItemModel>>();

            var service = Substitute.For<FilterService>();
            service.QuerySport().Returns(sports);

            var handler = new FilterHandler(service);

            // Act
            var model = await handler.Handle(new SportHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(sports));
        }

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightBetType()
        {
            // Arrange
            var bettypes = fixture.Create<IEnumerable<FilterItemModel>>();

            var service = Substitute.For<FilterService>();
            service.QueryBetType(Arg.Compat.Any<string>()).Returns(bettypes);

            var handler = new FilterHandler(service);

            // Act
            var model = await handler.Handle(new BetTypeHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(bettypes));
        }

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightCurrencies()
        {
            // Arrange
            var currencies = fixture.Create<IEnumerable<FilterItemModel>>();

            var service = Substitute.For<FilterService>();
            service.QueryCurrency().Returns(currencies);

            var handler = new FilterHandler(service);

            // Act
            var model = await handler.Handle(new CurrencyHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(currencies));
        }

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightLeague()
        {
            // Arrange
            var leagues = fixture.Create<IEnumerable<LeagueModel>>();

            var service = Substitute.For<FilterService>();
            service.QueryLeague(Arg.Compat.Any<string>(), Arg.Compat.Any<string>(), Arg.Compat.Any<bool>()).Returns(leagues);

            var handler = new FilterHandler(service);

            // Act
            var model = await handler.Handle(new LeagueHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(leagues));
        }
    }
}