using NUnit.Framework;
using System.Web.Http.Results;
using UniversalReports.HouseWinLoss.NumberGame.BetType;

namespace UniversalReports.HouseWinLoss.Tests.Controllers
{
    public class NumberGameBetTypeControllerTests : BaseControllerTests
    {
        [Test]
        [Category("ControllersTests")]
        public void Json_Successful()
        {
            const string ControllerName = "NumberGame.BetType.NumberGameBetTypeController";
            var queryModel = TestDataLoader.Load<QueryModel>(ControllerName, "queryModel");
            var expected = TestDataLoader.LoadTestContent(ControllerName, "expected");
            var controller = GetControllerWithRawWinLoss(ControllerName);

            var methodInfo = controller.GetType().GetMethod("Json", new[] { queryModel.GetType() });
            var result = methodInfo.Invoke(controller, new object[] { queryModel });
            var resultContent = ((JsonResult<JsonResultModel>)result).Content;

            ComparisonAssert.AreEqualJson(expected, resultContent);
        }
    }
}
