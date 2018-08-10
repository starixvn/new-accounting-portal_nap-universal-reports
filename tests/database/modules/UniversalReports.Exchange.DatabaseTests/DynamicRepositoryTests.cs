using System;
using System.Linq;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using NUnit.Framework;

namespace UniversalReports.Exchange.DatabaseTests
{
    [TestFixture]
    public class DynamicRepositoryTests
    {
        [Test]
        public async Task LicenseeSp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new Filter.Licensee.Criteria();

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<Filter.Licensee.LicenseeModel>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.LicenseeId, Is.Not.Zero);
            Assert.That(firstModel.LicenseeName, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task SportSp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new Filter.Sport.Criteria();

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<Filter.Sport.SportModel>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.SportType, Is.Not.Zero);
            Assert.That(firstModel.SportName, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task ExchangeQuerySp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new Report.Criteria()
            {
                FromDate = DateTime.Now.AddYears(-30),
                ToDate = DateTime.Now,
                LicenseeId = "1, 2, 3",
                SportType = "1,2,4,7,7522"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<Report.ExchangeEntity>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.LicenseeName, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.MemberCount, Is.Not.Zero);
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.TurnOver, Is.Not.Zero);
            Assert.That(firstModel.MemberWinLoss, Is.Not.Zero);
            Assert.That(firstModel.MemberCommission, Is.Not.Zero);
            Assert.That(firstModel.MemberTotal, Is.Not.Zero);
            Assert.That(firstModel.LicenseeWinLoss, Is.Not.Zero);
            Assert.That(firstModel.LicenseeCommission, Is.Not.Zero);
            Assert.That(firstModel.LicenseeTotal, Is.Not.Zero);
            Assert.That(firstModel.CompanyWinLoss, Is.Not.Zero);
            Assert.That(firstModel.LicenseeCommission, Is.Not.Zero);
            Assert.That(firstModel.PayToSupplier, Is.Not.Zero);
            Assert.That(firstModel.CompanyNetIncome, Is.Not.Zero);
        }
    }
}
