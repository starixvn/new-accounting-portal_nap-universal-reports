using System.Web.Http;
using Fanex.Excel.Models;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;
using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.MVC.Results;

namespace UniversalReports.CN88WinLoss.Common.MatchDetail
{
    public class CN88MatchDetailController : ApiController
    {
        private readonly WinLossService service;

        private readonly GridOptionsBuilder builder;

        private readonly MatchGridOptionColumnDecorator decorator;

        public CN88MatchDetailController(
            WinLossService service,
            GridOptionsBuilder builder,
            MatchGridOptionColumnDecorator decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        protected IHttpActionResult Json(WinLossCriteria criteria)
        {
            var gridOptions = GetGridOptions(criteria, string.Empty);
            return Json(gridOptions);
        }

        protected IHttpActionResult Excel(WinLossCriteria criteria, string title, string sheetName)
        {
            var gridOptions = GetGridOptions(criteria, title);
            return new FanexExcelResult(gridOptions, sheetName);
        }

        private GridOptions GetGridOptions(WinLossCriteria criteria, string title)
        {
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, title);
            return decorator.Build(gridOptions);
        }
    }
}