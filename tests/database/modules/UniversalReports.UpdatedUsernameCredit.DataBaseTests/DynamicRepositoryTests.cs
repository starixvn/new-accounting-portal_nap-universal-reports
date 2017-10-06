using System;
using System.Linq;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using NUnit.Framework;
using UniversalReports.UpdatedUsernameCredit.UpdatedCredit;
using UniversalReports.UpdatedUsernameCredit.UpdatedUsername;

namespace UniversalReports.UpdatedUsernameCredit.DataBaseTests
{
    [TestFixture]
    public class DynamicRepositoryTests
    {
        [Test]
        public async Task UpdatedCredit_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new UpdatedCredit.Criteria
            {
                FromDate = DateTime.Today.AddYears(-3),
                ToDate = DateTime.Today.AddDays(1),
                Username = string.Empty
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<UpdatedCreditEntity>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.Year, Is.Not.Zero);
            Assert.That(firstModel.Month, Is.Not.Zero);
            Assert.That(firstModel.LogDate, Is.GreaterThan(DateTime.MinValue));
            Assert.That(firstModel.Department, Is.Not.Empty);
            Assert.That(firstModel.Admin, Is.Not.Empty);
            Assert.That(firstModel.Username, Is.Not.Empty);
            Assert.That(firstModel.Level, Is.Not.Empty);
            Assert.That(firstModel.Headline, Is.Not.Empty);
            Assert.That(firstModel.Super, Is.Not.Empty);
            Assert.That(firstModel.Master, Is.Not.Empty);
            Assert.That(firstModel.Agent, Is.Not.Empty);
            Assert.That(firstModel.OldValue, Is.Not.Null);
            Assert.That(firstModel.NewValue, Is.Not.Null);
            Assert.That(firstModel.Department, Is.Not.Empty);
        }

        [Test]
        public async Task UpdatedUsername_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new UpdatedUsername.Criteria
            {
                FromDate = DateTime.Today.AddYears(-3),
                ToDate = DateTime.Today.AddDays(1),
                Username = string.Empty
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<UpdatedUsernameEntity>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.Year, Is.Not.Zero);
            Assert.That(firstModel.Month, Is.Not.Zero);
            Assert.That(firstModel.LogDate, Is.GreaterThan(DateTime.MinValue));
            Assert.That(firstModel.Department, Is.Not.Empty);
            Assert.That(firstModel.Admin, Is.Not.Empty);
            Assert.That(firstModel.CurrentUsername, Is.Not.Empty);
            Assert.That(firstModel.Level, Is.Not.Empty);
            Assert.That(firstModel.Headline, Is.Not.Empty);
            Assert.That(firstModel.Super, Is.Not.Empty);
            Assert.That(firstModel.Master, Is.Not.Empty);
            Assert.That(firstModel.Agent, Is.Not.Empty);
            Assert.That(firstModel.TrackingValue, Is.Not.Empty);
        }
    }
}
