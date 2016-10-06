using Newtonsoft.Json;
using NUnit.Framework;

namespace UniversalReports.NG2Statistic.Tests
{
    internal class ComparisonAssert
    {
        internal static void AreEqualJson(object expected, object actual)
        {
            var expectedJson = JsonConvert.SerializeObject(expected, Formatting.Indented);
            var actualJson = JsonConvert.SerializeObject(actual, Formatting.Indented);

            Assert.AreEqual(expectedJson, actualJson);
        }

        internal static void AreEqualJson(string expectedJson, object actual)
        {
            var actualJson = JsonConvert.SerializeObject(actual, Formatting.Indented);

            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}