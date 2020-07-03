using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalReports.SBPerformance.Common;

namespace UniversalReports.SBPerformance.UnitTests.Common
{
    [TestFixture]
    [Category("SBPerformance")]
    public class DataSourceChooserTests
    {
        [Test]
        [TestCase(-1, ExpectedResult = "bettrans")]
        [TestCase(2, ExpectedResult = "Warehouse")]
        public string GetSource_WithTimeRang_ReturnRightSource(int timeRange)
        {
            var service = new DataSourceChooserImp();
            return service.GetSource(timeRange);
        }
    }
}