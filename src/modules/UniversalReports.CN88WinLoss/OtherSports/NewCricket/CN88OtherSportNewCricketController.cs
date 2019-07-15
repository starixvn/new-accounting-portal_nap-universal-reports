using System.Web.Http;
using AutoMapper;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;
using UniversalReports.CN88WinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.CN88WinLoss.OtherSports.NewCricket
{
    [RoutePrefix("api/cn88-win-loss-by-products/other-sports/new-cricket/bet-type")]
    public class CN88OtherSportNewCricketController : ApiController
    {
        private readonly WinLossService service;
        private readonly GridOptionsBuilder builder;
        private readonly GridOptionColumnDecorator decorator;

        public CN88OtherSportNewCricketController(
            WinLossService service,
            GridOptionsBuilder builder,
            GridOptionColumnDecoratorFull decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            var winLoss = service.Query(criteria);
            var gridOptions = builder.Build(winLoss, string.Empty);
            gridOptions = decorator.Build(gridOptions, "Bet Type");

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            var winLoss = service.Query(criteria);
            var gridOptions = builder.Build(winLoss, string.Empty);
            gridOptions = decorator.Build(gridOptions, "Bet Type");
            gridOptions.TitleInfoText = queryModel.Title;

            return new FanexExcelResult(gridOptions, Constants.SheetName);
        }
    }
}