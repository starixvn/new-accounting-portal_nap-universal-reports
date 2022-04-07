using AutoMapper;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.MatchDetailByCode;

namespace UniversalReports.HouseWinLoss.NumberGame.MatchDetail
{
    [RoutePrefix("api/house-win-loss-by-products/number-game/match-detail")]
    public class NumberGameMatchDetailController : MatchDetailByCodeController
    {
        public NumberGameMatchDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecoratorByCode decorator)
            : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<NumberGameDrilldownCriteria>(queryModel);
            return Json(criteria);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<NumberGameDrilldownCriteria>(queryModel);
            return Excel(criteria, queryModel.Title);
        }
    }
}