using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.CompanyWinLoss.Soccer.BetType;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Soccer.SumBetType
{
    [RoutePrefix("api/company-win-loss/soccer/sum-bettype")]
    public class SoccerSumBetTypeController : ApiController
    {
        private readonly WinLossService service;
        private readonly GridOptionBuilder builder;

        public SoccerSumBetTypeController(WinLossService service, GridOptionBuilder builder)
        {
            this.service = service;
            this.builder = builder;
        }

        [Route("")]
        public IHttpActionResult SportType(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = service.Query(criteria);
                var gridOptions = builder.FromWinLossModel(winlosses, string.Empty);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = service.Query(criteria);
                var gridOptions = builder.FromWinLossModel(winlosses, queryModel.Title);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}
