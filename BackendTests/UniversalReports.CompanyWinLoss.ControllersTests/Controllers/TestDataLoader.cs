using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;

namespace UniversalReports.CompanyWinLoss.ControllersTests.Controllers
{
    internal class TestDataLoader
    {
        internal static T Load<T>(string controllerName, string name, [CallerFilePath] string sourceFilePath = "")
        {
            var sourceFileDirectory = Path.GetDirectoryName(sourceFilePath);
            var dataFilePath = $"{sourceFileDirectory}\\TestData\\{controllerName}-{name}.json";
            var text = File.ReadAllText(dataFilePath);

            return JsonConvert.DeserializeObject<T>(text);
        }

        internal static string LoadTestContent(string controllerName, string name, [CallerFilePath] string sourceFilePath = "")
        {
            var sourceFileDirectory = Path.GetDirectoryName(sourceFilePath);
            var dataFilePath = $"{sourceFileDirectory}\\TestData\\{controllerName}-{name}.json";
            return File.ReadAllText(dataFilePath);
        }
    }
}
