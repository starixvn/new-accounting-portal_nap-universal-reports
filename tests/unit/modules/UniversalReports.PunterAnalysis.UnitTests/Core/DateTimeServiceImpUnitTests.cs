using NUnit.Framework;
using System;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.UnitTests.Core
{
    public class DateTimeServiceImpUnitTests
    {
        private static object[] weekOfYearIso8601Cases =
        {
            new object[] { new DateTime(2017, 1, 02), 1 },
            new object[] { new DateTime(2017, 1, 03), 1 },
            new object[] { new DateTime(2017, 1, 06), 1 },
            new object[] { new DateTime(2017, 1, 12), 2 },
            new object[] { new DateTime(2017, 1, 19), 3 },
            new object[] { new DateTime(2017, 1, 28), 4 },
            new object[] { new DateTime(2017, 1, 31), 5 }
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
        [TestCaseSource("weekOfYearIso8601Cases")]
        public void GetWeekOfYearIso8601_Test(DateTime date, int week)
        {
            // Arrange
            var service = new DateTimeServiceImp();

            // Act
            var result = service.GetWeekOfYearIso8601(date);

            // Assert
            Assert.AreEqual(result, week);
        }
    }
}
