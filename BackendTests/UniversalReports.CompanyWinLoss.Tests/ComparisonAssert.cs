using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace UniversalReports.CompanyWinLoss.Tests
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

            File.WriteAllText(@"D:\out.json", actualJson);
            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}
