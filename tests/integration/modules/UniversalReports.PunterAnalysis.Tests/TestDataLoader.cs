using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace UniversalReports.PunterAnalysis.Tests
{
    internal static class TestDataLoader
    {
        internal static T Load<T>(string name)
        {
            var testDirectory = TestContext.CurrentContext.TestDirectory;

            var dataFilePath = $"{testDirectory}\\TestCases\\{name}";
            var text = File.ReadAllText(dataFilePath);

            return JsonConvert.DeserializeObject<T>(text);
        }
    }
}