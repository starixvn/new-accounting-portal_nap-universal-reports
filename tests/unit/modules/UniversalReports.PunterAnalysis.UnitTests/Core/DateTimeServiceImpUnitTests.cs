using NUnit.Framework;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.UnitTests.Core
{
    public class DateTimeServiceImpUnitTests
    {
        [Test]
        [TestCase(2012, 0, ExpectedResult = "12/26/2011")]
        [TestCase(2012, 1, ExpectedResult = "1/2/2012")]
        [TestCase(2012, 26, ExpectedResult = "6/25/2012")]
        [TestCase(2012, 52, ExpectedResult = "12/24/2012")]
        [TestCase(2012, 53, ExpectedResult = "12/31/2012")]

        public string GetFirstDateOfWeekIso8601_Test(int year, int week)
        {
            var service = new DateTimeServiceImp();
            var firstDateOfWeekISO8601 = service.GetFirstDateOfWeekISO8601(year, week);

            return firstDateOfWeekISO8601.ToShortDateString();
        }
    }
}
