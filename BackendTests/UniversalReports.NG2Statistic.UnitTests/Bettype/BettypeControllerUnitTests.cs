using System.Web.Http.Results;
using Fanex.Excel.Models;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Asserts.Compare;
using NUnit.Framework;
using UniversalReports.Core.TestUtility;
using UniversalReports.NG2Statistic.BaseServices;
using UniversalReports.NG2Statistic.Bettype;

namespace UniversalReports.NG2Statistic.UnitTests.Bettype
{
    [TestFixture]
    public class BettypeControllerUnitTests
    {
        [Test]
        public void Bettype_SpecificQueryModel_ReturnRightGridOptions()
        {
            var queryModel = TestDataProvider.Load<QueryModel>("BettypeController", "queryModel");
            var fakeData = TestDataProvider.Load<BettypeModel>("BettypeController", "fakeData");
            var expectedData = TestDataProvider.LoadTestContent("BettypeController", "expectedData");
            var service = Substitute.For<BettypeService>();
            service.Query(Arg.Any<QueryModel>()).Returns(fakeData);
            var headerBuilder = new BaseGridOptionHeaderColumnImp();
            var builder = new GridOptionsBuilderImp(headerBuilder);
            var sorting = new SortingServiceImp();

            var controller = new BettypeController(service, builder, sorting);
            var result = controller.Bettype(queryModel) as JsonResult<GridOptions>;

            Assert.That(JsonConvert.SerializeObject(result.Content, Formatting.Indented), Compares.To(expectedData));
        }
    }
}