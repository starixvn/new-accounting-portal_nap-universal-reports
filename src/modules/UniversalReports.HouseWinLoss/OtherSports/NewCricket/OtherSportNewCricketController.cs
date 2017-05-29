using AutoMapper;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.OtherSports.NewCricket
{
    [RoutePrefix("api/house-win-loss-by-products/other-sports/new-cricket/bet-type")]
    public class OtherSportNewCricketController : ApiController
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