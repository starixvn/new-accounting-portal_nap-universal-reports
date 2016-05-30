using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.CompanyWinLoss.Soccer.BetType;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Soccer.SumBetType
{
    [RoutePrefix("api/company-win-loss/soccer/sum-bettype")]
    public class SoccerSumBetTypeController : ApiController
    {
        private readonly WinLossService service;

        private readonly GridOptionsBuilder builder;

        private readonly GridOptionColumnDecorator decorator;

        public SoccerSumBetTypeController(WinLossService service, GridOptionsBuilder builder, GridOptionColumnDecoratorVirtual decorator)
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
                var gridOptions = builder.FromWinLossModel(winlosses, string.Empty);
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
                var gridOptions = builder.FromWinLossModel(winlosses, queryModel.Title);
                gridOptions = decorator.Build(gridOptions, "Bet Type", 180);

                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}
