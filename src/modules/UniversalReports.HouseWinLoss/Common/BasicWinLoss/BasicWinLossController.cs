using System.Web.Http;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Common.BasicWinLoss
{
    public class BasicWinLossController : ApiController
    {
        protected BasicWinLossController()
        {
        }

        protected BasicWinLossController(
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