using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace UniversalReports.CompanyWinLoss.UnitTests.TestUtility
{
    internal class ComparisonAssert
    {
        internal static void AreEqual(object expected, object actual)
        {
            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);
            File.WriteAllText(@"D:\path.json", actualJson);
            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}
