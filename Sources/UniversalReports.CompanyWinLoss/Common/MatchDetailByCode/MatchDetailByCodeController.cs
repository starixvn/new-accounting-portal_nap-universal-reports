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

        protected MatchDetailByCodeController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecorator decorator)
        {
            Service = service;
            Builder = builder;
            Decorator = decorator;
        }

        protected WinLossService Service { get; }

        protected GridOptionsBuilder Builder { get; }

        protected MatchGridOptionColumnDecorator Decorator { get; }

        public IHttpActionResult Json(WinLossCriteria criteria)
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