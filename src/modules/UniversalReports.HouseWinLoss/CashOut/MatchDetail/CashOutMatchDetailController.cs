using AutoMapper;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.MatchDetail;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.CashOut.MatchDetail
{
    [RoutePrefix("api/house-win-loss-by-products/cash-out/match-detail")]
    public class CashOutMatchDetailController : MatchDetailController
    {
        public CashOutMatchDetailController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecoratorBasic decorator)
            : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<UniversalThirdPartyMatchDetailCriteria>(queryModel);
            return Json(criteria);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<UniversalThirdPartyMatchDetailCriteria>(queryModel);
            return Excel(criteria, queryModel.Title, Constants.SheetName);
        }
    }
}