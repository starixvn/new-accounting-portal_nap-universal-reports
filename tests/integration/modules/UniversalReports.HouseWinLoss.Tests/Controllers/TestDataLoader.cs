using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;

namespace UniversalReports.HouseWinLoss.Tests.Controllers
{
    internal class TestDataLoader
    {
        internal static T Load<T>(string controllerName, string name)
        {
            var sourceFileDirectory = TestContext.CurrentContext.TestDirectory;
            var dataFilePath = $"{sourceFileDirectory}\\TestData\\{controllerName}-{name}.json";
            var text = File.ReadAllText(dataFilePath);

            return JsonConvert.DeserializeObject<T>(text);
        }

        internal static string LoadTestContent(string controllerName, string name)
        {
            var sourceFileDirectory = TestContext.CurrentContext.TestDirectory;
            var dataFilePath = $"{sourceFileDirectory}\\TestData\\{controllerName}-{name}.json";
            return File.ReadAllText(dataFilePath);
        }
    }
}