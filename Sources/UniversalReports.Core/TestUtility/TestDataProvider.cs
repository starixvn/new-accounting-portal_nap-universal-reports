using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace UniversalReports.Core.TestUtility
{
    public static class TestDataProvider
    {
        public static T Load<T>(string controllerName, string name, [CallerFilePath] string sourceFilePath = "")
        {
            var sourceFileDirectory = Path.GetDirectoryName(sourceFilePath);
            var dataFilePath = $"{sourceFileDirectory}\\TestData\\{controllerName}-{name}.json";
            var text = File.ReadAllText(dataFilePath);

            return JsonConvert.DeserializeObject<T>(text);
        }

        public static string LoadTestContent(string controllerName, string name, [CallerFilePath] string sourceFilePath = "")
        {
            var sourceFileDirectory = Path.GetDirectoryName(sourceFilePath);
            var dataFilePath = $"{sourceFileDirectory}\\TestData\\{controllerName}-{name}.json";
            return File.ReadAllText(dataFilePath);
        }

        public static void SaveTestContent(string controllerName, string name, string json, [CallerFilePath] string sourceFilePath = "")
        {
            var sourceFileDirectory = Path.GetDirectoryName(sourceFilePath);
            var dataFilePath = $"{sourceFileDirectory}\\TestData\\{controllerName}-{name}.json";
            File.WriteAllText(dataFilePath, json);
        }

        public static void SaveTestContent(string controllerName, string name, object @object, [CallerFilePath] string sourceFilePath = "")
        {
            var sourceFileDirectory = Path.GetDirectoryName(sourceFilePath);
            var dataFilePath = $"{sourceFileDirectory}\\TestData\\{controllerName}-{name}.json";
            var json = JsonConvert.SerializeObject(@object, Formatting.Indented);
            File.WriteAllText(dataFilePath, json);
        }
    }
}