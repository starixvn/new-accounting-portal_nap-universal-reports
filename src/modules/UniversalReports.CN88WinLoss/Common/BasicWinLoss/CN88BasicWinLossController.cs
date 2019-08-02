using System.Web.Http;
using Fanex.Excel.Models;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;
using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.CN88WinLoss.Common.BasicWinLoss
{
    public class CN88BasicWinLossController : ApiController
    {
        public CN88BasicWinLossController(
            BasicWinLossService service,
            BasicGridOptionsBuilder builder,
            GridOptionColumnDecorator decorator)
        {
            Service = service;
            Builder = builder;
            Decorator = decorator;
        }

        protected BasicWinLossService Service { get; }

        protected BasicGridOptionsBuilder Builder { get; }

        protected GridOptionColumnDecorator Decorator { get; }

        protected IHttpActionResult Json(WinLossCriteria criteria, string mainColumnText, int mainColumnWidth = 180)
        {
            var gridOptions = GetGridOptions(criteria, mainColumnText, string.Empty, mainColumnWidth);
            return Json(gridOptions);
        }

        [Route("excel")]
        protected IHttpActionResult Excel(WinLossCriteria criteria, string mainColumnText, string title, int mainColumnWidth = 180)
        {
            var gridOptions = GetGridOptions(criteria, mainColumnText, title, mainColumnWidth);
            return new FanexExcelResult(gridOptions, Constants.SheetName);
        }

        protected GridOptions GetGridOptions(WinLossCriteria criteria, string mainColumnText, string title = "", int mainColumnWidth = 180)
        {
            var winlosses = Service.Query(criteria);
            var gridOptions = Builder.Build(winlosses, title);
            return Decorator.Build(gridOptions, mainColumnText, mainColumnWidth);
        }
    }
}