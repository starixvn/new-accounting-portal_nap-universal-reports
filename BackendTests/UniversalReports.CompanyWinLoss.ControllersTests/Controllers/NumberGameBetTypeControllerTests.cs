using NUnit.Framework;
using System.Web.Http.Results;
using UniversalReports.CompanyWinLoss.NumberGame.BetType;

namespace UniversalReports.CompanyWinLoss.ControllersTests.Controllers
{
    public class NumberGameBetTypeControllerTests : BaseControllerTests
    {
        [Test]
        public void Json_Successful()
        {
            const string ControllerName = "NumberGame.BetType.NumberGameBetTypeController";
            var queryModel = TestDataLoader.Load<NumberGame.BetType.QueryModel>(ControllerName, "queryModel");
            var expected = TestDataLoader.LoadTestContent(ControllerName, "expected");
            var controller = GetControllerWithRawWinLoss(ControllerName);

            var methodInfo = controller.GetType().GetMethod("Json", new[] { queryModel.GetType() });
            var result = methodInfo.Invoke(controller, new[] { queryModel });
            var resultContent = (result as JsonResult<JsonResultModel>).Content;

            ComparisonAssert.AreEqualJson(expected, resultContent);
        }
    }
}
