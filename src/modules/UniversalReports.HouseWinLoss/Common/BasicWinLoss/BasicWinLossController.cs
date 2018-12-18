using System.Collections.Generic;
using System.Web.Http;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Common.BasicWinLoss
{
    [RoutePrefix("api/house-win-loss-by-products/basic-grid")]
    public class BasicWinLossController : ApiController
    {
        private readonly BasicWinLossModelFactory modelFactory;

        private readonly BasicWinLossService service;

        private readonly BasicGridOptionsBuilder builder;

        private readonly GridOptionColumnDecorator decorator;

        public BasicWinLossController(
            BasicWinLossModelFactory modelFactory,
           BasicWinLossService service,
           BasicGridOptionsBuilder builder,
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
