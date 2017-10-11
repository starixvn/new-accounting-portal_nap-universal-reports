using Fanex.Data.Repository;
using NUnit.Framework;
using System;
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
        public async Task PunterPerformanceSummaryMonth_Test_NoDatabaseException()
        {
            // Arrange
            var criteria = new MonthCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2100, 12, 1),
                Depth = 1,
                Username = "312rmb"
            };

            // Act
            var repository = new DynamicRepository();
            await repository.FetchAsync<MonthStatistic>(criteria);
        }

        [Test]
        public async Task PunterPerformanceSummaryBetType_Test_NoDatabaseException()
        {
            // Arrange
            var criteria = new BetTypeCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2100, 12, 1),
                Depth = 1,
                Username = "312rmb"
            };

            // Act
            var repository = new DynamicRepository();
            await repository.FetchAsync<BetTypeStatistic>(criteria);
        }

        [Test]
        public async Task PunterPerformanceSummaryEvent_Test_NoDatabaseException()
        {
            // Arrange
            var criteria = new EventCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2100, 12, 1),
                Depth = 1,
                Username = "312rmb"
            };

            // Act
            var repository = new DynamicRepository();
            await repository.FetchAsync<EventStatistic>(criteria);
        }

        [Test]
        public async Task PunterPerformanceSummaryProductTurnover_Test_NoDatabaseException()
        {
            // Arrange
            var criteria = new ProductTurnoverCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2100, 12, 1),
                Depth = 1,
                Username = "MR1RMB30328"
            };

            // Act
            var repository = new DynamicRepository();
            await repository.FetchAsync<ProductTurnoverStatistic>(criteria);
        }

        [Test]
        public async Task PunterPerformanceSummarySport_Test_NoDatabaseException()
        {
            // Arrange
            var criteria = new Performance.Summary.Criteria.SportCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2100, 12, 1),
                Depth = 1,
                Username = "MR1RMB30328"
            };

            // Act
            var repository = new DynamicRepository();
            await repository.FetchAsync<Performance.Summary.Model.SportStatistic>(criteria);
        }

        [Test]
        public async Task PunterPerformanceSportsbookBetCount_Test_NoDatabaseException()
        {
            // Arrange
            var criteria = new BetCountCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2100, 12, 1),
                Depth = 1,
                Username = "312rmb"
            };

            // Act
            var repository = new DynamicRepository();
            await repository.FetchAsync<BetCountStatistic>(criteria);
        }

        [Test]
        public async Task PunterPerformanceSportsbookSport_Test_NoDatabaseException()
        {
            // Arrange
            var criteria = new SportsbookCriteria.SportCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2100, 12, 1),
                Depth = 1,
                Username = "MR1RMB30328"
            };

            // Act
            var repository = new DynamicRepository();
            await repository.FetchAsync<SportsbookModel.SportStatistic>(criteria);
        }
    }
}