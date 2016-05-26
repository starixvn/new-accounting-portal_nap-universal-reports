using Fanex.Excel.Models;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetail
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
            this.Service = service;
            this.Builder = builder;
            this.Decorator = decorator;
        }

        private WinLossService Service { get; }

        private GridOptionsBuilder Builder { get; }

        private MatchGridOptionColumnDecorator Decorator { get; }

        protected IHttpActionResult Json(WinLossCriteria criteria)
        {
            if (ModelState.IsValid)
            {
                var gridOptions = GetGridOptions(criteria, string.Empty);
                return Json(gridOptions);
            }

            return null;
        }

        protected IHttpActionResult Excel(WinLossCriteria criteria, string title)
        {
            if (ModelState.IsValid)
            {
                var gridOptions = GetGridOptions(criteria, title);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }

        protected GridOptions GetGridOptions(WinLossCriteria criteria, string title)
        {
            var winlosses = Service.Query(criteria);
            var gridOptions = Builder.Build(winlosses, title);
            return Decorator.Build(gridOptions);
        }
    }
}