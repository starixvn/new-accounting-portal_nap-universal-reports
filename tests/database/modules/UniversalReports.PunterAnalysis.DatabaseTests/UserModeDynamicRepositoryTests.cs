using System;
using System.Linq;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.League.Model;
using UniversalReports.PunterAnalysis.SportType.Model;
using UniversalReports.PunterAnalysis.Summary.Model;
using AssociatedAccountCriteria = UniversalReports.PunterAnalysis.AssociatedAccount.Model.UserRoleQueryCriteria;
using AvailableDatabaseFilter = UniversalReports.PunterAnalysis.Filter.AvailableDatabase;
using AvailableDateRangeFilter = UniversalReports.PunterAnalysis.Filter.AvailableDateRange;
using BetCountCriteria = UniversalReports.PunterAnalysis.BetCount.Model.Criteria;
using BetTypeCriteria = UniversalReports.PunterAnalysis.BetType.Model.Criteria;
using LeagueCriteria = UniversalReports.PunterAnalysis.League.Model.Criteria;
using LeagueFilter = UniversalReports.PunterAnalysis.Filter.League;
using ProductSportBetTypeFilter = UniversalReports.PunterAnalysis.Filter.ProductSportBetType;
using SportsbookSportBetTypeFilter = UniversalReports.PunterAnalysis.Filter.SportsbookSportBetType;
using SportTypeCriteria = UniversalReports.PunterAnalysis.SportType.Model.Criteria;
using SportTypeLeagueFilter = UniversalReports.PunterAnalysis.Filter.SportTypeLeague;
using SummaryCriteria = UniversalReports.PunterAnalysis.Summary.Model.Criteria;
using UsernameSuggestionFilter = UniversalReports.PunterAnalysis.Filter.UsernameSuggestion;

namespace UniversalReports.PunterAnalysis.DatabaseTests
{
    public class UserModeDynamicRepositoryTests
    {
        [Test]
        public async Task AvailableDatabaseSp_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new AvailableDatabaseFilter.QueryCriteria();

            // Act
            var repository = new DynamicRepository();
            var status = await repository.GetAsync<int>(criteria);

            // Assert
            Assert.That(status, Is.Not.Zero);
        }

        [Test]
        public async Task AssociatedAccountSp_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new AssociatedAccountCriteria
            {
                ListUserName = "B15T6666XXX,B49TAA75111,M83RM0320B,PKMP88245,S95M0505005"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<UserRoleModel>(criteria);

            // Assert
            var firstModel = models.First();
            Assert.That(firstModel.Username, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.RoleName, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task BetCountSp_Test_NoDatabaseException()
        {
            // Arrange
            var criteria = new BetCountCriteria
            {
                PeriodType = 4,
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2100, 12, 1),
                CustId = 1280,
                ListCombinationId = "100001,100003",
                LeagueId = 0,
                SportId = 1,
                BetTypeId = 1,
                LiveStatusId = 1
            };

            // Act
            var repository = new DynamicRepository();
            await repository.FetchAsync<BetCountModel>(criteria);
        }

        [Test]
        public async Task BetTypeSp_Test_NoDatabaseException()
        {
            // Arrange
            var criteria = new BetTypeCriteria
            {
                PeriodType = 3,
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2100, 12, 1),
                CustId = 19575728,
                ListCombinationId = "21802681,21802682,21802683,21901011",
                LeagueId = 0,
                SportId = 1,
                OrderBy = 1,
                SortBy = 1
            };

            // Act
            var repository = new DynamicRepository();
            await repository.FetchAsync<BetTypeModel>(criteria);
        }

        [Test]
        public async Task SportTypeSp_Test_NoDatabaseException()
        {
            // Arrange
            var criteria = new SportTypeCriteria
            {
                PeriodType = 4,
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2100, 12, 1),
                CustId = 19575728,
                ListCombinationId = "21802681,21802682,21802683,21901011",
                LeagueId = 0,
                OrderBy = 1,
                SortBy = 1
            };

            // Act
            var repository = new DynamicRepository();
            await repository.FetchAsync<SportTypeModel>(criteria);
        }

        [Test]
        public async Task SummarySp_Test_NoDatabaseException()
        {
            // Arrange
            var criteria = new SummaryCriteria
            {
                TopRow = 10,
                OrderBy = 1,
                SortBy = 2,
                PeriodType = 4,
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2100, 12, 1),
                Depth = 1,
                ListCombinationId = "21802681,21802682,21802683,21901011",
                LeagueId = 0
            };

            // Act
            var repository = new DynamicRepository();
            await repository.FetchAsync<SummaryModel>(criteria);
        }

        [Test]
        public async Task LeagueSp_Test_NoDatabaseException()
        {
            // Arrange
            var criteria = new LeagueCriteria
            {
                PeriodType = 3,
                FromDate = new DateTime(2016, 8, 1),
                ToDate = new DateTime(2100, 12, 1),
                CustId = 19575728,
                ListCombinationId = "21802681,21802682,21802683,21901011",
                LeagueId = 0,
                SportId = 1,
                BetTypeId = 1
            };

            // Act
            var repository = new DynamicRepository();
            await repository.FetchAsync<LeagueRawModel>(criteria);
        }

        [Test]
        public async Task UserSiteSp_Test_ReturnsNotNullSiteName()
        {
            // Arrange
            var criteria = new UserSiteQueryCriteria
            {
                CustId = 19575728
            };

            // Act
            var repository = new DynamicRepository();
            var site = await repository.GetAsync<string>(criteria);

            // Assert
            Assert.That(site, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task PunterProductSportBetTypeSp_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new ProductSportBetTypeFilter.QueryCriteria();

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<ProductSportBetTypeFilter.ProductSportBetTypeEntity>(criteria);

            // Assert
            var firstModel = models.First();
            Assert.That(firstModel.ProductName, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.SportGroup, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.SportName, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.BetTypeName, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.Value, Is.Not.Zero);
            Assert.That(firstModel.RenderType, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public async Task PunterLeagueSp_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new LeagueFilter.QueryCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2100, 12, 1),
                SportId = 1
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<LeagueFilter.LeagueEntity>(criteria);

            // Assert
            var firstModel = models.First();
            Assert.That(firstModel.Id, Is.Not.Zero);
            Assert.That(firstModel.Name, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task PunterAvailableDatabaseSp_Test_ReturnsTrue()
        {
            // Arrange
            var criteria = new AvailableDatabaseFilter.QueryCriteria();

            // Act
            var repository = new DynamicRepository();
            var available = await repository.GetAsync<bool>(criteria);

            // Assert
            Assert.True(available);
        }

        [Test]
        public async Task PunterAvailableDateRangeSp_Test_ReturnsNonNullDateRange()
        {
            // Arrange
            var criteria = new AvailableDateRangeFilter.QueryCriteria();

            // Act
            var repository = new DynamicRepository();
            var range = await repository.GetAsync<AvailableDateRangeFilter.DateRange>(criteria);

            // Assert
            Assert.That(range.MinDate, Is.GreaterThan(DateTime.MinValue));
            Assert.That(range.MaxDate, Is.GreaterThan(DateTime.MinValue));
        }

        [Test]
        public async Task PunterUsernameSuggestionSp_Test_ReturnsNonEmptyListOfUsername()
        {
            // Arrange
            var criteria = new UsernameSuggestionFilter.QueryCriteria { CustId = 0, Username = "a" };

            // Act
            var repository = new DynamicRepository();
            var usernames = await repository.FetchAsync<string>(criteria);

            // Assert
            Assert.That(usernames, Has.Count.GreaterThan(0));
        }

        [Test]
        public async Task PunterSportsbookSportBetTypeSp_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new SportsbookSportBetTypeFilter.QueryCriteria();

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<SportsbookSportBetTypeFilter.SportsbookSportBetTypeEntity>(criteria);

            // Assert
            var firstModel = models.First();
            Assert.That(firstModel.SportType, Is.Not.Zero);
            Assert.That(firstModel.SportName, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.BetTypeName, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.CombinationId, Is.Not.Zero);
        }

        [Test]
        public async Task PunterSportTypeLeagueSp_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new SportTypeLeagueFilter.QueryCriteria
            {
                SportId = 1,
                SearchText = "champion,league",
                SearchExactly = false
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<SportTypeLeagueFilter.SportTypeLeagueEntity>(criteria);

            // Assert
            var firstModel = models.First();
            Assert.That(firstModel.LeagueId, Is.Not.Zero);
            Assert.That(firstModel.LeagueName, Is.Not.Null.And.Not.Empty);
        }
    }
}