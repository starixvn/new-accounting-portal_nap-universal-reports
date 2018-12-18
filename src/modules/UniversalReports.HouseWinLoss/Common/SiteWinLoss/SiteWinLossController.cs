using System.Collections.Generic;
using System.Web.Http;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Common.SiteWinLoss
{
    [RoutePrefix("api/house-win-loss-by-products/basic-site-grid")]
    public class SiteWinLossController : ApiController
    {
        private readonly BasicWinLossModelFactory modelFactory;

        private readonly WinLossService service;

        private readonly GridOptionsBuilder builder;

        private readonly GridOptionColumnDecorator decorator;

        public SiteWinLossController(
            BasicWinLossModelFactory modelFactory,
            WinLossService service,
            GridOptionsBuilder builder,
            GridOptionColumnDecorator decorator)
        {
            this.modelFactory = modelFactory;
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(Dictionary<string, object> queryModel)
        {
            var gridOptions = GetGridOptions(queryModel);

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(Dictionary<string, object> queryModel)
        {
            var gridOptions = GetGridOptions(queryModel);

            return new FanexExcelResult(gridOptions, queryModel["sheetName"].ToString());
        }

        private GridOptions GetGridOptions(Dictionary<string, object> queryModel)
        {
            var criteria = modelFactory.CreateCriteria(queryModel);
            var decorationModel = modelFactory.CreateGridDecorationModel(queryModel);
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, decorationModel.Title);
            return decorator.Build(gridOptions, decorationModel.MainColumnText, decorationModel.MainColumnWidth);
        }
    }
}
