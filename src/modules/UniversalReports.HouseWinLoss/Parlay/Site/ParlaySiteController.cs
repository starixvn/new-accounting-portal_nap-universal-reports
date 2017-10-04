using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Parlay.Site
{
    [RoutePrefix("api/house-win-loss-by-products/parlay/site")]
    public class ParlaySiteController : ApiController
    {
        private readonly WinLossService service;

        private readonly GridOptionsBuilder builder;

        private readonly GridOptionColumnDecorator decorator;

        public ParlaySiteController(WinLossService service, GridOptionsBuilder builder, GridOptionColumnDecoratorBasic decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, string.Empty);
            gridOptions = decorator.Build(gridOptions, queryModel.Site);

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, queryModel.Title);
            gridOptions = decorator.Build(gridOptions, queryModel.Site);

            return new FanexExcelResult(gridOptions, Constants.SheetName);
        }
    }
}