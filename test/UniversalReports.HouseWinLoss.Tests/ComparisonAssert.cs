using Newtonsoft.Json;
using NUnit.Framework;

namespace UniversalReports.HouseWinLoss.Tests
{
    internal static class ComparisonAssert
    {
        internal static void AreEqualJson(string expectedJson, object actual)
        {
            var actualJson = JsonConvert.SerializeObject(actual, Formatting.Indented);

            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}