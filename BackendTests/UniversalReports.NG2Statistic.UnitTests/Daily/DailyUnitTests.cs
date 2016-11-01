using Fanex.Repository;
using Newtonsoft.Json;
using NUnit.Asserts.Compare;
using NUnit.Framework;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Core.TestUtility;
using UniversalReports.NG2Statistic.BaseServices;
using UniversalReports.NG2Statistic.Daily;

namespace UniversalReports.NG2Statistic.UnitTests.Daily
{
    [TestFixture]
    [Category("NG2 Daily Unit Tests")]
    public class DailyUnitTests
    {
        private SimpleRepository simpleRepository;
        private BalanceUpService balance;

        [OneTimeSetUp]
        public void Init()
        {
            simpleRepository = new SimpleRepositoryImp();
            balance = new BalanceUpServiceImp(simpleRepository);
        }

        [Test]
        public void Query_ReturnRightReportByDaily()
        {
            //// Arrange

            var queryModel = TestDataProvider.Load<QueryModel>("DailyController", "queryModel");
            var fakeData = TestDataProvider.Load<DailyModel>("DailyController", "fakeData");
            var expected = TestDataProvider.LoadTestContent("DailyController", "expectedData");

            //// Act
            var builder = new GridOptionsBuilderImp();
            var header = new BaseGridOptionHeaderColumnImp();
            var gridOptions = builder.Build(fakeData, queryModel.Title);
            var result = header.Build(gridOptions, "Date", "Winlostdate", queryModel);

            var objectResult = JsonConvert.SerializeObject(result, Formatting.Indented);

            //// Assert
            Assert.That(objectResult, Compares.To(expected));
        }
    }
}