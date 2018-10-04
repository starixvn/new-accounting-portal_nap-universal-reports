using System;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;
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

        [Test]
        public async Task PunterMemberPerformanceCriteria_Test_NoDatabaseException()
        {
            // Arrange
            var criteria = new MemberPerformanceCriteria
            {
                FromDate = new DateTime(2016, 1, 1),
                ToDate = new DateTime(2100, 12, 1),
                Username = "AB88MBEuro,NH3333QU004,SDFF0000000,TVA4HT000006,SDED0002000,mbb11,VC8877938,M863HK01325,SDF10201000,NH34H002001",
                ListCombinationId = "100001,100002,100003,100902,118999,200001,200002,200003,200007,200008,200010,200012,200020,1100001,1100002,1100003,1100010,1100020",
                LeagueId = 0,
                OrderBy = 1,
                SortBy = 2,
                PeriodType = 3
            };

            // Act
            var repository = new DynamicRepository();
            await repository.FetchAsync<SportsbookModel.SportStatistic>(criteria);
        }
    }
}