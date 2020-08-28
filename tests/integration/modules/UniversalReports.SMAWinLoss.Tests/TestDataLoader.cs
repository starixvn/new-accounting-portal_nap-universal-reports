using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace UniversalReports.SMAWinLoss.Tests
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

        internal static void Write(string name, object value)
        {
            var testDirectory = TestContext.CurrentContext.TestDirectory;
            var dataFilePath = $"{testDirectory}\\TestCases\\{name}";
            string json = JsonConvert.SerializeObject(value);
            File.WriteAllText(dataFilePath, json);
        }
    }
}