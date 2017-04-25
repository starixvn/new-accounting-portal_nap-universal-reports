using Fanex.Data.Repository;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Performance.Summary.Criteria;
using UniversalReports.PunterAnalysis.Performance.Summary.Model;

namespace UniversalReports.PunterAnalysis.DatabaseTests
{
    public class PerformanceModeDynamicRepositoryTests
    {
        [Test]
        public async Task PunterPerformanceMonth_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new MonthCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2016, 12, 1),
                Depth = 1,
                Username = "S99THTN01001"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<MonthStatistic>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.Turnover, Is.Not.Zero);
        }

        [Test]
        public async Task PunterPerformanceBetType_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new BetTypeCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2016, 12, 1),
                Depth = 1,
                Username = "S99THTN01001"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<BetTypeStatistic>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.Turnover, Is.Not.Zero);
        }

        [Test]
        public async Task PunterPerformanceEvent_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new EventCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2016, 12, 1),
                Depth = 1,
                Username = "S99THTN01001"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<EventStatistic>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.Turnover, Is.Not.Zero);
        }

        [Test]
        public async Task PunterPerformanceProductTurnover_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new ProductTurnoverCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2016, 12, 1),
                Depth = 1,
                Username = "S99THTN01001"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<ProductTurnoverStatistic>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.ProductName, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.Turnover, Is.Not.Zero);
        }

        [Test]
        public async Task PunterPerformanceSport_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new SportCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2016, 12, 1),
                Depth = 1,
                Username = "S99THTN01001"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<SportStatistic>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.Turnover, Is.Not.Zero);
        }
    }
}