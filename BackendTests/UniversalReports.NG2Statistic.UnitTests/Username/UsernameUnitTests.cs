using Fanex.Repository;
using Newtonsoft.Json;
using NUnit.Asserts.Compare;
using NUnit.Framework;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Core.TestUtility;
using UniversalReports.NG2Statistic.BaseServices;
using UniversalReports.NG2Statistic.UserName;

namespace UniversalReports.NG2Statistic.UnitTests.Username
{
    [TestFixture]
    [Category("NG2 Username Unit Tests")]
    public class UsernameUnitTests
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
        public void Query_ReturnRightReportByUsername()
        {
            //// Arrange

            var queryModel = TestDataProvider.Load<QueryModel>("UserNameController", "queryModel");
            var fakeData = TestDataProvider.Load<UserNameModel>("UserNameController", "fakeData");
            var expected = TestDataProvider.LoadTestContent("UserNameController", "expectedData");

            //// Act
            var builder = new GridOptionsBuilderImp();
            var header = new GridOptionHeaderColumnImp();
            var gridOptions = builder.Build(fakeData, queryModel.Title);
            var result = header.Build(gridOptions, queryModel);

            var objectResult = JsonConvert.SerializeObject(result, Formatting.Indented);

            //// Assert
            Assert.That(objectResult, Compares.To(expected));
        }
    }
}