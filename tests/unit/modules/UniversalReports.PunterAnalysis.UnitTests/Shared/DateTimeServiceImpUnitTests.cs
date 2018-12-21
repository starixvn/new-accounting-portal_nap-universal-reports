using System;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.UnitTests.Shared
{
    public class DateTimeServiceImpUnitTests
    {
        public static object[] WeekOfYearIso8601Cases => new object[]
        {
            new object[] { new DateTime(2017, 1, 2), 1 },
            new object[] { new DateTime(2017, 1, 3), 1 },
            new object[] { new DateTime(2017, 1, 4), 1 },
            new object[] { new DateTime(2017, 1, 5), 1 },
            new object[] { new DateTime(2017, 1, 6), 1 },
            new object[] { new DateTime(2017, 1, 7), 1 },
            new object[] { new DateTime(2017, 1, 8), 1 },
            new object[] { new DateTime(2017, 1, 12), 2 },
            new object[] { new DateTime(2017, 1, 19), 3 },
            new object[] { new DateTime(2017, 1, 28), 4 },
            new object[] { new DateTime(2017, 1, 31), 5 }
        };

        public static object[] FormatDateTimeCases => new[]
        {
            new object[] { 0, new DateTime(2017, 1, 23), "01/2017" },
            new object[] { 1, new DateTime(2017, 1, 23), "2017-01-23" },
            new object[] { 2, new DateTime(2017, 1, 23), "01/2017 - Week 4" },
            new object[] { 3, new DateTime(2017, 1, 23), "01/2017" },
            new object[] { 4, new DateTime(2017, 1, 23), "01/2017" },
            new object[] { 5, new DateTime(2017, 1, 23), "01/2017" }
        };

        [Test]
        [TestCase(2012, 0, ExpectedResult = "12/26/2011")]
        [TestCase(2012, 1, ExpectedResult = "1/2/2012")]
        [TestCase(2012, 26, ExpectedResult = "6/25/2012")]
        [TestCase(2012, 52, ExpectedResult = "12/24/2012")]
        [TestCase(2012, 53, ExpectedResult = "12/31/2012")]
        public string GetFirstDateOfWeekIso8601_Test(int year, int week)
        {
            var service = new DateTimeServiceImp();
            var firstDateOfWeekISO8601 = service.GetFirstDateOfWeekIso8601(year, week);

            return firstDateOfWeekISO8601.ToShortDateString();
        }

        [Test]
        [TestCaseSource(nameof(WeekOfYearIso8601Cases))]
        public void GetWeekOfYearIso8601_Test(DateTime date, int week)
        {
            // Arrange
            // Act
            var result = DateTimeServiceImp.GetWeekOfYearIso8601(date);

            // Assert
            Assert.AreEqual(result, week);
        }

        [Test]
        [TestCaseSource(nameof(FormatDateTimeCases))]
        public void FormatDateTimeByPeriodType_WithPeriodType_ReturnRightDateTimeFormat(int periodType, DateTime date, string formatDate)
        {
            // Arrange
            var service = new DateTimeServiceImp();

            // Act
            var result = service.FormatDateTimeByPeriodType(periodType, date);

            // Assert
            Assert.AreEqual(result, formatDate);
        }
    }
}