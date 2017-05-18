using Fanex.Data.Repository;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Performance.Sportsbook.Criteria;
using UniversalReports.PunterAnalysis.Performance.Sportsbook.Model;
using UniversalReports.PunterAnalysis.Performance.Summary.Criteria;
using UniversalReports.PunterAnalysis.Performance.Summary.Model;
using SportsbookCriteria = UniversalReports.PunterAnalysis.Performance.Sportsbook.Criteria;
using SportsbookModel = UniversalReports.PunterAnalysis.Performance.Sportsbook.Model;

namespace UniversalReports.PunterAnalysis.DatabaseTests
{
    public class PerformanceModeDynamicRepositoryTests
    {
        [Test]
        public async Task PunterPerformanceSummaryMonth_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new MonthCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2016, 12, 1),
                Depth = 1,
                Username = "312rmb"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<MonthStatistic>(criteria);

            // Assert
            if (models.Any())
            {
                var firstModel = models.First();
                Assert.That(firstModel.BetCount, Is.Not.Zero);
                Assert.That(firstModel.Turnover, Is.Not.Zero);
            }
        }

        [Test]
        public async Task PunterPerformanceSummaryBetType_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new BetTypeCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2016, 12, 1),
                Depth = 1,
                Username = "312rmb"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<BetTypeStatistic>(criteria);

            // Assert
            if (models.Any())
            {
                var firstModel = models.First();
                Assert.That(firstModel.BetCount, Is.Not.Zero);
                Assert.That(firstModel.Turnover, Is.Not.Zero);
            }
        }

        [Test]
        public async Task PunterPerformanceSummaryEvent_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new EventCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2016, 12, 1),
                Depth = 1,
                Username = "312rmb"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<EventStatistic>(criteria);


            // Assert
            if (models.Any())
            {
                var firstModel = models.First();
                Assert.That(firstModel.EventType, Is.Not.Null.And.Not.Empty);
                Assert.That(firstModel.BetCount, Is.Not.Zero);
                Assert.That(firstModel.Turnover, Is.Not.Zero);
                Assert.That(firstModel.WinLoss, Is.Not.Zero);
            }
        }

        [Test]
        public async Task PunterPerformanceSummaryProductTurnover_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new ProductTurnoverCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2016, 12, 1),
                Depth = 1,
                Username = "MR1RMB30328"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<ProductTurnoverStatistic>(criteria);

            // Assert
            if (models.Any())
            {
                var firstModel = models.First();
                Assert.That(firstModel.ProductName, Is.Not.Null.And.Not.Empty);
                Assert.That(firstModel.Turnover, Is.Not.Zero);
            }
        }

        [Test]
        public async Task PunterPerformanceSummarySport_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new Performance.Summary.Criteria.SportCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2016, 12, 1),
                Depth = 1,
                Username = "MR1RMB30328"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<Performance.Summary.Model.SportStatistic>(criteria);

            // Assert
            if (models.Any())
            {
                var firstModel = models.First();
                Assert.That(firstModel.BetCount, Is.Not.Zero);
                Assert.That(firstModel.Turnover, Is.Not.Zero);
            }
        }

        [Test]
        public async Task PunterPerformanceSportsbookBetCount_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new BetCountCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2016, 12, 1),
                Depth = 1,
                Username = "312rmb"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<BetCountStatistic>(criteria);

            // Assert
            if (models.Any())
            {
                var firstModel = models.First();
                Assert.That(firstModel.EventType, Is.Not.Null.And.Not.Empty);
                Assert.That(firstModel.Turnover, Is.Not.Zero);
            }
        }

        [Test]
        public async Task PunterPerformanceSportsbookSport_Test_ColumnIsMappedCorrectly()
        {
            // Arrange
            var criteria = new SportsbookCriteria.SportCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2016, 12, 1),
                Depth = 1,
                Username = "MR1RMB30328"
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<SportsbookModel.SportStatistic>(criteria);

            // Assert
            if (models.Any())
            {
                var firstModel = models.First();
                Assert.That(firstModel.BetCount, Is.Not.Zero);
                Assert.That(firstModel.Turnover, Is.Not.Zero);
                Assert.That(firstModel.WinLoss, Is.Not.Zero);
            }
        }
    }
}