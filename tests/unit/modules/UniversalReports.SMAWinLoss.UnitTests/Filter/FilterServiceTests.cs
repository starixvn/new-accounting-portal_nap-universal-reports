using AutoFixture;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.SMAWinLoss.Filter;

namespace UniversalReports.SMAWinLoss.UnitTests.Filter
{
    [TestFixture]
    [Category("SMAWinLoss")]
    public class FilterServiceTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task QuerySite_WithSubtituteReposity_ReturnRightSite()
        {
            // Arrange
            var sites = fixture.Create<IEnumerable<Site>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<Site>(Arg.Compat.Any<SiteCriteria>()).Returns(sites);

            var service = new FilterServiceImp(repository);

            // Act
            var model = await service.GetSites();

            // Assert
            Assert.That(model, IsDeeplyEqual.To(sites));
        }

        [Test]
        public async Task QueryCurrency_WithSubtituteReposity_ReturnRightCurrency()
        {
            // Arrange
            var currencies = fixture.Create<IEnumerable<Currency>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<Currency>(Arg.Compat.Any<CurrencyCriteria>()).Returns(currencies);

            var service = new FilterServiceImp(repository);

            // Act
            var model = await service.GetCurrencies();

            // Assert
            Assert.That(model, IsDeeplyEqual.To(currencies));
        }

        [Test]
        public async Task QuerySport_WithSubtituteReposity_ReturnRightSport()
        {
            // Arrange
            var sports = fixture.Create<IEnumerable<Sport>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<Sport>(Arg.Compat.Any<SportCriteria>()).Returns(sports);

            var service = new FilterServiceImp(repository);

            // Act
            var model = await service.GetSports();

            // Assert
            Assert.That(model, IsDeeplyEqual.To(sports));
        }

        [Test]
        public async Task QueryLeagueGroup_WithSubtituteReposity_ReturnRightLeagueGroup()
        {
            // Arrange
            var leagueGroups = fixture.Create<IEnumerable<LeagueGroup>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LeagueGroup>(Arg.Compat.Any<LeagueGroupCriteria>()).Returns(leagueGroups);

            var service = new FilterServiceImp(repository);

            // Act
            var model = await service.GetLeagueGroup();

            // Assert
            Assert.That(model, IsDeeplyEqual.To(leagueGroups));
        }

        [Test]
        public async Task QueryAvailableDatabase_WithSubtituteReposity_ReturnRightSite()
        {
            // Arrange
            var availableDatabase = fixture.Create<bool>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.GetAsync<bool>(Arg.Compat.Any<AvailableDatabaseCriteria>()).Returns(availableDatabase);

            var service = new FilterServiceImp(repository);

            // Act
            var model = await service.GetAvailableDatabase();

            // Assert
            Assert.That(model, IsDeeplyEqual.To(availableDatabase));
        }
    }
}