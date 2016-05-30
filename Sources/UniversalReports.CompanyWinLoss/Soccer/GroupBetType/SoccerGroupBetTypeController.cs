using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.CompanyWinLoss.Soccer.BetType;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
{
    [RoutePrefix("api/company-win-loss/soccer/group-bettype")]
    public class SoccerGroupBetTypeController : ApiController
    {
        private readonly WinLossService service;
        private readonly GridOptionsBuilder builder;
        private readonly GridOptionColumnDecorator decorator;

        public SoccerGroupBetTypeController(WinLossService service, GridOptionsBuilder builder, GridOptionColumnDecoratorVirtual decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = service.Query(criteria);
                var gridOptions = builder.Build(winlosses, string.Empty);
                gridOptions = decorator.Build(gridOptions, "Bet Type", 180);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = service.Query(criteria);
                var gridOptions = builder.Build(winlosses, queryModel.Title);
                gridOptions = decorator.Build(gridOptions, "Bet Type", 180);

                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}
