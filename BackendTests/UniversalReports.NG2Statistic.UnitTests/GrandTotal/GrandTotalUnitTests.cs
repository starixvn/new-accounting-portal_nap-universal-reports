using Fanex.Repository;
using Newtonsoft.Json;
using NUnit.Asserts.Compare;
using NUnit.Framework;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Core.TestUtility;
using UniversalReports.NG2Statistic.BaseServices;
using UniversalReports.NG2Statistic.GrandTotal;

namespace UniversalReports.NG2Statistic.UnitTests.GrandTotal
{
    [TestFixture]
    [Category("NG2 Grand Total Unit Tests")]
    public class GrandTotalUnitTests
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
        public void Query_ReturnRightReportByBettype()
        {
            //// Arrange

            var queryModel = TestDataProvider.Load<QueryModel>("GrandTotalController", "queryModel");
            var fakeData = TestDataProvider.Load<GrandTotalModel>("GrandTotalController", "fakeData");
            var expected = TestDataProvider.LoadTestContent("GrandTotalController", "expectedData");

            //// Act
            var builder = new GridOptionsBuilderImp();
            var header = new GridOptionHeaderColumnImp();
            var gridOptions = builder.Build(fakeData, queryModel.Title);
            var result = header.Build(gridOptions);

            var objectResult = JsonConvert.SerializeObject(result, Formatting.Indented);

            //// Assert
            Assert.That(objectResult, Compares.To(expected));
        }
    }
}