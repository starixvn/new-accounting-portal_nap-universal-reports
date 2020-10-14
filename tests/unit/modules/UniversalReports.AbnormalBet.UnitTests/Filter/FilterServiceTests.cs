using AutoFixture;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Criteria;
using UniversalReports.AbnormalBet.Filter;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.UnitTests.Filter
{
    [TestFixture]
    [Category("AbnormalBet")]
    public class FilterServiceTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task QuerySite_WithSubtituteReposity_ReturnRightSite()
        {
            // Arrange
            var sites = fixture.Create<IEnumerable<FilterItemModel>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<FilterItemModel>(Arg.Compat.Any<SiteQueryCriteria>()).Returns(sites);

            var service = new FilterServiceImp(repository);

            // Act
            var model = await service.QuerySite();

            // Assert
            Assert.That(model, IsDeeplyEqual.To(sites));
        }

        [Test]
        public async Task QueryReason_WithSubtituteReposity_ReturnRightReason()
        {
            // Arrange
            var reasons = fixture.Create<IEnumerable<FilterItemModel>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<FilterItemModel>(Arg.Compat.Any<ReasonQueryCriteria>()).Returns(reasons);

            var service = new FilterServiceImp(repository);

            // Act
            var model = await service.QueryReason();

            // Assert
            Assert.That(model, IsDeeplyEqual.To(reasons));
        }

        [Test]
        public async Task QuerySport_WithSubtituteReposity_ReturnRightSport()
        {
            // Arrange
            var sports = fixture.Create<IEnumerable<FilterItemModel>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<FilterItemModel>(Arg.Compat.Any<SportQueryCriteria>()).Returns(sports);

            var service = new FilterServiceImp(repository);

            // Act
            var model = await service.QuerySport();

            // Assert
            Assert.That(model, IsDeeplyEqual.To(sports));
        }

        [Test]
        public async Task QueryBetType_WithSubtituteReposity_ReturnRightBetType()
        {
            // Arrange
            var bettypes = fixture.Create<IEnumerable<FilterItemModel>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<FilterItemModel>(Arg.Compat.Any<BetTypeQueryCriteria>()).Returns(bettypes);

            var service = new FilterServiceImp(repository);

            // Act
            var model = await service.QueryBetType(string.Empty);

            // Assert
            Assert.That(model, IsDeeplyEqual.To(bettypes));
        }

        [Test]
        public async Task QueryCurrency_WithSubtituteReposity_ReturnRightCurencies()
        {
            // Arrange
            var currencies = fixture.Create<IEnumerable<FilterItemModel>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<FilterItemModel>(Arg.Compat.Any<CurrencyQueryCriteria>()).Returns(currencies);

            var service = new FilterServiceImp(repository);

            // Act
            var model = await service.QueryCurrency();

            // Assert
            Assert.That(model, IsDeeplyEqual.To(currencies));
        }

        [Test]
        public async Task QueryLeague_WithSubtituteReposity_ReturnRightLeague()
        {
            // Arrange
            var league = fixture.Create<IEnumerable<FilterItemModel>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<FilterItemModel>(Arg.Compat.Any<LeagueQueryCriteria>()).Returns(league);

            var service = new FilterServiceImp(repository);

            // Act
            var model = await service.QueryLeague(string.Empty, string.Empty, false);

            // Assert
            Assert.That(model, IsDeeplyEqual.To(league));
        }
    }
}