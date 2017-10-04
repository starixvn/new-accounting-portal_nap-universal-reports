using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using System.IO;

namespace UniversalReports.PunterAnalysis.Tests
{
    internal static class TestDataLoader
    {
        internal static T Load<T>(string name, string dateTimeFormat = "yyyy-MM-dd hh:mm:ss")
        {
            var testDirectory = TestContext.CurrentContext.TestDirectory;

            var dataFilePath = $"{testDirectory}\\TestCases\\{name}";
            var text = File.ReadAllText(dataFilePath);
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = dateTimeFormat };
            return JsonConvert.DeserializeObject<T>(text, dateTimeConverter);
        }
    }
}