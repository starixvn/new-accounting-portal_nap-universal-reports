using Fanex.Excel.Models;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail
{
    public abstract class MatchDetailController : ApiController
    {
        protected MatchDetailController()
        {
        }

        protected MatchDetailController(
            WinLossService service,
            GridOptionsBuilder builder,
            MatchGridOptionColumnDecorator decorator)
        {
            Service = service;
            Builder = builder;
            Decorator = decorator;
        }

        private WinLossService Service { get; }

        private GridOptionsBuilder Builder { get; }

        private MatchGridOptionColumnDecorator Decorator { get; }

        protected IHttpActionResult Json(WinLossCriteria criteria)
        {
            var gridOptions = GetGridOptions(criteria, string.Empty);
            return Json(gridOptions);
        }

        protected IHttpActionResult Excel(WinLossCriteria criteria, string title)
        {
            var gridOptions = GetGridOptions(criteria, title);
            return new FanexExcelResult(gridOptions, Constants.SheetName);
        }

        protected GridOptions GetGridOptions(WinLossCriteria criteria, string title)
        {
            var winlosses = Service.Query(criteria);
            var gridOptions = Builder.Build(winlosses, title);
            return Decorator.Build(gridOptions);
        }
    }
}