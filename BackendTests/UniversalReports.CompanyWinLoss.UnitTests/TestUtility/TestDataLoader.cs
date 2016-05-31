using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Runtime.CompilerServices;

namespace UniversalReports.CompanyWinLoss.UnitTests.TestUtility
{
    internal class TestDataLoader
    {        
        internal static T Load<T>(string name, [CallerFilePath] string sourceFilePath = "")
        {
            var dataFilePath = $"{Path.GetDirectoryName(sourceFilePath)}\\{Path.GetFileNameWithoutExtension(sourceFilePath)}.{name}.json";
            var text = File.ReadAllText(dataFilePath);

            return JsonConvert.DeserializeObject<T>(text);
        }
    }
}
