using Fanex.Repository;
using Newtonsoft.Json;
using NUnit.Asserts.Compare;
using NUnit.Framework;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Core.TestUtility;
using UniversalReports.NG2Statistic.BaseServices;
using UniversalReports.NG2Statistic.Daily;

namespace UniversalReports.Core.Tests.SortUtility
{
    [TestFixture]
    [Category("NG2 Sorting Unit Tests")]
    public class SortUnitTests
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
        public void Query_SortingRightReport()
        {
            //// Arrange

            var queryModel = TestDataProvider.Load<QueryModel>("SortUtility", "queryModel");
            var fakeData = TestDataProvider.Load<DailyModel>("SortUtility", "fakeData");
            var expected = TestDataProvider.LoadTestContent("SortUtility", "expectedData");

            //// Act
            var builder = new GridOptionsBuilderImp();
            var service = new DailyServiceImp(balance);
            var result = service.SortData(fakeData, queryModel);

            var objectResult = JsonConvert.SerializeObject(result, Formatting.Indented);

            //// Assert
            Assert.That(objectResult, Compares.To(expected));
        }
    }
}