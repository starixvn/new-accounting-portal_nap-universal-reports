using System.Web.Http;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Common.MatchDetailByCode
{
    public class MatchDetailByCodeController : ApiController
    {
        private readonly WinLossService service;

        private readonly GridOptionsBuilder builder;

        private readonly MatchGridOptionColumnDecorator decorator;

        public MatchDetailByCodeController(WinLossService service, GridOptionsBuilder builder, MatchGridOptionColumnDecorator decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

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

        private GridOptions GetGridOptions(WinLossCriteria criteria, string title)
        {
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, title);

            return decorator.Build(gridOptions);
        }
    }
}