using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UniversalReports.Core.Tests.TestUtility
{
    internal static class TestDataLoader
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

        internal static void SaveTestContent(string controllerName, string name, string json, [CallerFilePath] string sourceFilePath = "")
        {
            var sourceFileDirectory = Path.GetDirectoryName(sourceFilePath);
            var dataFilePath = $"{sourceFileDirectory}\\TestData\\{controllerName}-{name}.json";
            File.WriteAllText(dataFilePath, json);
        }

        internal static void SaveTestContent(string controllerName, string name, object @object, [CallerFilePath] string sourceFilePath = "")
        {
            var sourceFileDirectory = Path.GetDirectoryName(sourceFilePath);
            var dataFilePath = $"{sourceFileDirectory}\\TestData\\{controllerName}-{name}.json";
            var json = JsonConvert.SerializeObject(@object, Formatting.Indented);
            File.WriteAllText(dataFilePath, json);
        }
    }
}
