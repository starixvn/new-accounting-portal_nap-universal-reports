using Fanex.Repository;
using Newtonsoft.Json;
using NUnit.Asserts.Compare;
using NUnit.Framework;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Core.TestUtility;
using UniversalReports.NG2Statistic.BaseServices;
using UniversalReports.NG2Statistic.Bettype;

namespace UniversalReports.NG2Statistic.UnitTests.Bettype
{
    [TestFixture]
    [Category("NG2 Bettype Unit Tests")]
    public class BettypeUnittests
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

            var queryModel = TestDataProvider.Load<QueryModel>("BettypeController", "queryModel");
            var fakeData = TestDataProvider.Load<BettypeModel>("BettypeController", "fakeData");
            var expected = TestDataProvider.LoadTestContent("BettypeController", "expectedData");

            //// Act
            var builder = new GridOptionsBuilderImp();
            var header = new BaseGridOptionHeaderColumnImp();
            var gridOptions = builder.Build(fakeData, queryModel.Title);
            var result = header.Build(gridOptions, "Bet Type", "Bettype", queryModel);

            var objectResult = JsonConvert.SerializeObject(result, Formatting.Indented);

            //// Assert
            Assert.That(objectResult, Compares.To(expected));
        }
    }
}