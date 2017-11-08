using System.Web.Http;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail3rd
{
    public class MatchDetail3rdController : ApiController
    {
        private readonly WinLossService winlossService;

        private readonly GridOptionsBuilder match3rdGridBuilder;

        private readonly MatchGridOptionColumnDecorator3rd decorator;

        public MatchDetail3rdController(
            WinLossService winlossService,
            GridOptionsBuilder match3rdGridBuilder,
            MatchGridOptionColumnDecorator3rd decorator)
        {
            this.winlossService = winlossService;
            this.match3rdGridBuilder = match3rdGridBuilder;
            this.decorator = decorator;
        }

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

        private GridOptions GetGridOptions(WinLossCriteria criteria, string title)
        {
            var winlosses = winlossService.Query(criteria);
            var gridOptions = match3rdGridBuilder.Build(winlosses, title);
            return decorator.Build(gridOptions);
        }
    }
}
