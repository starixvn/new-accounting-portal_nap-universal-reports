using Fanex.Excel.Models;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailByCode
{
    public abstract class MatchDetailByCodeController : ApiController
    {
        protected MatchDetailByCodeController()
        {
        }

        protected MatchDetailByCodeController(WinLossService service, GridOptionBuilder builder, MatchGridOptionColumnDecorator decorator)
        {
            this.Service = service;
            this.Builder = builder;
            this.Decorator = decorator;
        }

        protected WinLossService Service { get; }

        protected GridOptionBuilder Builder { get; }

        protected MatchGridOptionColumnDecorator Decorator { get; }

        public IHttpActionResult Json(WinLossCriteria criteria)
        {
            if (ModelState.IsValid)
            {
                var gridOptions = GetGridOptions(criteria, string.Empty);
                gridOptions = Decorator.Build(gridOptions);

                return Json(gridOptions);
            }

            return null;
        }

        protected IHttpActionResult Excel(WinLossCriteria criteria, string title)
        {
            if (ModelState.IsValid)
            {
                var gridOptions = GetGridOptions(criteria, title);
                gridOptions = Decorator.Build(gridOptions);

                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }

        protected GridOptions GetGridOptions(WinLossCriteria criteria, string title)
        {
            var winlosses = Service.Query(criteria);
            return Builder.Build(winlosses, title);
        }
    }
}