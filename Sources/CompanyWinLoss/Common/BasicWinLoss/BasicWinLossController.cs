using Fanex.Excel.Models;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Common.BasicWinLoss
{
    public abstract class BasicWinLossController : ApiController
    {
        protected BasicWinLossController()
        {
        }

        protected BasicWinLossController(
            BasicWinLossService service,
            BasicGridOptionBuilder builder,
            GridOptionColumnDecorator decorator)
        {
            Service = service;
            Builder = builder;
            Decorator = decorator;
        }

        protected BasicWinLossService Service { get; }

        protected BasicGridOptionBuilder Builder { get; }

        protected GridOptionColumnDecorator Decorator { get; }

        protected IHttpActionResult Json(WinLossCriteria criteria, string mainColumnText)
        {
            if (ModelState.IsValid)
            {
                var gridOptions = GetGridOptions(criteria, mainColumnText);
                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        protected IHttpActionResult Excel(WinLossCriteria criteria, string mainColumnText, string title)
        {
            if (ModelState.IsValid)
            {
                var gridOptions = GetGridOptions(criteria, mainColumnText, title);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }

        protected GridOptions GetGridOptions(WinLossCriteria criteria, string mainColumnText, string title = "")
        {
            var winlosses = Service.Query(criteria);
            var gridOptions = Builder.Build(winlosses, title);
            return Decorator.Build(gridOptions, mainColumnText);
        }
    }
}
