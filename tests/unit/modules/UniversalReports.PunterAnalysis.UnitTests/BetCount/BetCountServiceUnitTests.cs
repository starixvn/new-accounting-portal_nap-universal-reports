using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetCount;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.UnitTests.BetCount
{
    public class BetCountServiceUnitTests
    {
        public static object[] FormatDateTimeCases
        {
            get
            {
                return new[]
                {
                    new object[] { 0, new DateTime(2017, 1, 23), "01/2017" },
                    new object[] { 1, new DateTime(2017, 1, 23), "2017-01-23" },
                    new object[] { 2, new DateTime(2017, 1, 23), "01/2017 - Week 4" },
                    new object[] { 3, new DateTime(2017, 1, 23), "01/2017" },
                    new object[] { 4, new DateTime(2017, 1, 23), "01/2017" },
                    new object[] { 5, new DateTime(2017, 1, 23), "01/2017" }
                };
            }
        }

        [Test]
        public async Task Query_WithNewCriteria_ReturnRightBetCountModel()
        {
            // Arrange
            var fakeData = CreateBetCountRawModel();
            var expectedData = CreateBetCountModel();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<BetCountRawModel>(Arg.Any<Criteria>()).Returns(fakeData);

            var dateTimeService = Substitute.For<DateTimeService>();
            dateTimeService.GetWeekOfYearIso8601(Arg.Any<DateTime>()).Returns(4);

            var service = new BetCountServiceImp(repository, dateTimeService);

            // Act
            var result = await service.Query(new Criteria());

            // Assert
            Assert.That(result, IsDeeplyEqual.To(expectedData));
        }

        [Test]
        [TestCaseSource(nameof(FormatDateTimeCases))]
        public void FormatDateTimeByPeriodType_WithPeriodType_ReturnRightDateTimeFormat(int periodType, DateTime date, string formatDate)
        {
            // Arrange
            var repository = Substitute.For<IDynamicRepository>();
            var dateTimeService = Substitute.For<DateTimeService>();
            dateTimeService.GetWeekOfYearIso8601(Arg.Any<DateTime>()).Returns(4);
            var service = new BetCountServiceImp(repository, dateTimeService);

            // Act
            var result = service.FormatDateTimeByPeriodType(periodType, date);

            // Assert
            Assert.AreEqual(result, formatDate);
        }

        private List<BetCountRawModel> CreateBetCountRawModel()
        {
            return new List<BetCountRawModel>
            {
                new BetCountRawModel
                {
                    BetCount = 1,
                    DrawCount = 1,
                    WinCount = 1,
                    WinLoss = 100,
                    Date = new DateTime(2017, 1, 02)
                },
                new BetCountRawModel
                {
                    BetCount = 1,
                    DrawCount = 1,
                    WinCount = 1,
                    WinLoss = 100,
                    Date = new DateTime(2017, 1, 03)
                }
            };
        }

        private SummaryEntity<BetCountModel> CreateBetCountModel()
        {
            return new SummaryEntity<BetCountModel>
            {
                Entities = new List<BetCountModel>
                {
                    new BetCountModel
                    {
                        BetCount = 1,
                        DrawCount = 1,
                        WinCount = 1,
                        WinLoss = 100,
                        Date = "2017-01-02"
                    },
                    new BetCountModel
                    {
                        BetCount = 1,
                        DrawCount = 1,
                        WinCount = 1,
                        WinLoss = 100,
                        Date = "2017-01-03"
                    }
                },
                Total = new BetCountModel
                {
                    BetCount = 2,
                    DrawCount = 2,
                    WinCount = 2,
                    WinLoss = 200,
                    Date = string.Empty
                }
            };
        }
    }
}