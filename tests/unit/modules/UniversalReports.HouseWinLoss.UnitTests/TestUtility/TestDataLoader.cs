using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace UniversalReports.HouseWinLoss.UnitTests.TestUtility
{
    internal static class TestDataLoader
    {
        internal static T Load<T>(string name)
        {
            var directory = $"{TestContext.CurrentContext.TestDirectory}\\TestData";
            var dataFilePath = $"{directory}\\{name}.json";
            var text = File.ReadAllText(dataFilePath);

            return JsonConvert.DeserializeObject<T>(text);
        }
    }
}