using Fanex.Data.Repository;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.League.Model;
using UniversalReports.PunterAnalysis.SportType.Model;
using UniversalReports.PunterAnalysis.Summary.Model;
using AssociatedAccountCriteria = UniversalReports.PunterAnalysis.AssociatedAccount.Model.UserRoleQueryCriteria;
using BetCountCriteria = UniversalReports.PunterAnalysis.BetCount.Model.Criteria;
using BetTypeCriteria = UniversalReports.PunterAnalysis.BetType.Model.Criteria;
using DatabaseStatusCriteria = UniversalReports.PunterAnalysis.DatabaseStatus.Model.Criteria;
using LeagueCriteria = UniversalReports.PunterAnalysis.League.Model.Criteria;
using SportTypeCriteria = UniversalReports.PunterAnalysis.SportType.Model.Criteria;
using SummaryCriteria = UniversalReports.PunterAnalysis.Summary.Model.Criteria;

namespace UniversalReports.PunterAnalysis.DatabaseTests
{
    public class DynamicRepositoryTests
    {
        [Test]
        public async Task DatabaseStatusSp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new DatabaseStatusCriteria();

            // Act
            var repository = new DynamicRepository();
            var status = await repository.GetAsync<int>(criteria);

            // Assert
            Assert.That(status, Is.Not.Zero);
        }

        [Test]
        public async Task AssociatedAccountSp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new AssociatedAccountCriteria
            {
                ListUserName = "B15T6666XXX,B49TAA75111,M83RM0320B,PKMP88245,S95M0505005"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<UserRoleModel>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.Username, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.RoleName, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task BetCountSp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new BetCountCriteria
            {
                PeriodType = 3,
                FromDate = new DateTime(2016, 8, 1),
                ToDate = new DateTime(2016, 12, 1),
                CustId = 19575728,
                ListCombinationId = "21802681,21802682,21802683,21901011",
                SportId = 1,
                BetTypeId = 1,
                LiveStatusId = 1
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<BetCountModel>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.WinLoss, Is.Not.Zero);
            Assert.That(firstModel.WinCount, Is.Not.Zero);
            Assert.That(firstModel.DrawCount, Is.Not.Zero);
            Assert.That(firstModel.Date, Is.GreaterThan(DateTime.MinValue));
        }

        [Test]
        public async Task BetTypeSp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new BetTypeCriteria
            {
                PeriodType = 3,
                FromDate = new DateTime(2016, 8, 1),
                ToDate = new DateTime(2016, 12, 1),
                CustId = 19575728,
                ListCombinationId = "21802681,21802682,21802683,21901011",
                SportId = 1,
                OrderBy = 1,
                SortBy = 1
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<BetTypeModel>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.LiveBetCount, Is.Not.Zero);
            Assert.That(firstModel.LiveWinLoss, Is.Not.Zero);
            Assert.That(firstModel.LiveTurnover, Is.Not.Zero);
            Assert.That(firstModel.NonLiveBetCount, Is.Not.Zero);
            Assert.That(firstModel.NonLiveWinLoss, Is.Not.Zero);
            Assert.That(firstModel.NonLiveTurnover, Is.Not.Zero);
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.WinLoss, Is.Not.Zero);
            Assert.That(firstModel.Turnover, Is.Not.Zero);
            Assert.That(firstModel.BetTypeId, Is.Not.Zero);
            Assert.That(firstModel.BetTypeName, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task SportTypeSp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new SportTypeCriteria
            {
                PeriodType = 3,
                FromDate = new DateTime(2016, 8, 1),
                ToDate = new DateTime(2016, 12, 1),
                CustId = 19575728,
                ListCombinationId = "21802681,21802682,21802683,21901011",
                OrderBy = 1,
                SortBy = 1
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<SportTypeModel>(criteria);

            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.WinLoss, Is.Not.Zero);
            Assert.That(firstModel.Turnover, Is.Not.Zero);
            Assert.That(firstModel.SportId, Is.Not.Zero);
            Assert.That(firstModel.SportName, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task SummarySp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new SummaryCriteria
            {
                TopRow = 10,
                OrderBy = 1,
                SortBy = 2,
                PeriodType = 3,
                FromDate = new DateTime(2016, 8, 1),
                ToDate = new DateTime(2016, 12, 1),
                Depth = 1,
                ListCombinationId = "21802681,21802682,21802683,21901011",
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<SummaryModel>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.WinLoss, Is.Not.Zero);
            Assert.That(firstModel.Turnover, Is.Not.Zero);
            Assert.That(firstModel.CustId, Is.Not.Zero);
            Assert.That(firstModel.Username, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task LeagueSp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new LeagueCriteria
            {
                PeriodType = 3,
                FromDate = new DateTime(2016, 8, 1),
                ToDate = new DateTime(2016, 12, 1),
                CustId = 19575728,
                ListCombinationId = "21802681,21802682,21802683,21901011",
                SportId = 1,
                BetTypeId = 1,
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<LeagueRawModel>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.WinLoss, Is.Not.Zero);
            Assert.That(firstModel.Turnover, Is.Not.Zero);
            Assert.That(firstModel.Year, Is.Not.Zero);
            Assert.That(firstModel.Month, Is.Not.Zero);
            Assert.That(firstModel.Week, Is.Not.Zero);
            Assert.That(firstModel.LeagueId, Is.Not.Zero);
            Assert.That(firstModel.LeagueName, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task UserSiteSp_Test_ReturnNotNullSiteName()
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
    }
}