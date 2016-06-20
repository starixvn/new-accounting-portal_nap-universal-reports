using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.OtherSports.NewCricket
{
    [RoutePrefix("api/company-win-loss/other-sports/new-cricket/bet-type")]
    public class OtherSportNewCricketController : BasicWinLossController
    {
        private readonly WinLossService service;
        private readonly GridOptionsBuilder builder;
        private readonly GridOptionColumnDecorator decorator;

        public OtherSportNewCricketController(
            WinLossService service,
            GridOptionsBuilder builder,
            GridOptionColumnDecoratorVirtual decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            var winLoss = service.Query(criteria);
            var gridOptions = builder.Build(winLoss, string.Empty);
            gridOptions = decorator.Build(gridOptions, "Bet Type");

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            var winLoss = service.Query(criteria);
            var gridOptions = builder.Build(winLoss, string.Empty);
            gridOptions = decorator.Build(gridOptions, "Bet Type");
            gridOptions.TitleInfoText = queryModel.Title;

            return new FanexExcelResult(gridOptions, Constants.SheetName);
        }
    }
}
