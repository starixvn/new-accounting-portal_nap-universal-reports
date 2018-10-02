using System;
using System.Linq;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using NUnit.Framework;
using UniversalReports.ActualMemberBet.Filter;

namespace UniversalReports.ActualMemberBet.DatabaseTests
{
    [TestFixture]
    public class DynamicRepositoryTests
    {
        [Test]
        public async Task CurrencySp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new CurrencyCriteria();

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<Currency>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.CurrencyId, Is.Not.Zero);
            Assert.That(firstModel.CurrencyName, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task SiteSp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new SiteCriteria();

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<Site>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.SiteType, Is.Not.Zero);
            Assert.That(firstModel.SiteName, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task OddsSp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new OddsCriteria();

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<Odds>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.OddsType, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.OddsTypeName, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task ActualMemberBetProductQuerySp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new Product.Criteria()
            {
                FromDate = DateTime.Now.AddMonths(-3),
                ToDate = DateTime.Now,
                CurrencyId = -9999,
                OddsType = "1",
                SiteType = -9999
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<Product.ProductActualMemberBet>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.KeyId, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.ProductName, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.MemberTurnoverRM, Is.Not.Zero);
            Assert.That(firstModel.MemberNetWinLoss, Is.Not.Zero);
            Assert.That(firstModel.HouseRealTurnover, Is.Not.Zero);
            Assert.That(firstModel.HouseVirtualTurnover, Is.Not.Zero);
            Assert.That(firstModel.HouseRealIncome, Is.Not.Zero);
            Assert.That(firstModel.HouseVirtualWinLoss, Is.Not.Zero);
        }

        [Test]
        public async Task ActualMemberBetBettypeQuerySp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new Bettype.Criteria()
            {
                FromDate = DateTime.Now.AddYears(-3),
                ToDate = DateTime.Now,
                CurrencyId = -9999,
                OddsType = "1",
                SiteType = -9999,
                KeyId = "1#1#1"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<Bettype.BetTypeActualMemberBet>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.BettypeName, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.MemberTurnoverMYOdds, Is.Not.Zero);
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.MemberTurnoverRM, Is.Not.Zero);
            Assert.That(firstModel.MemberNetWinLoss, Is.Not.Zero);
            Assert.That(firstModel.HouseRealTurnoverMYOdds, Is.Not.Zero);
            Assert.That(firstModel.HouseVirtualTurnoverMyOdds, Is.Not.Zero);
            Assert.That(firstModel.HouseRealIncome, Is.Not.Zero);
            Assert.That(firstModel.HouseVirtualWinLoss, Is.Not.Zero);
        }

    }

}
