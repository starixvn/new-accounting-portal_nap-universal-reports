using Newtonsoft.Json;
using NUnit.Framework;

namespace UniversalReports.CompanyWinLoss.UnitTests.TestUtility
{
    internal class ComparisonExtension
    {
        internal static void AreEqual(object expected, object actual)
        {
            string expectedJson = JsonConvert.SerializeObject(expected);
            string actualJson = JsonConvert.SerializeObject(actual);

            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}
