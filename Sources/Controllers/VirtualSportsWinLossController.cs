using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using System.Web.Http;

namespace NAP.Reports.CompanyWinLoss.Controllers
{
    public class VirtualSportsWinLossController : ApiController
    {
        private VirtualSportsSportTypeSummaryWinLossService _summaryService;

        private SiteWinLossService _siteService;

        public VirtualSportsWinLossController(
            VirtualSportsSportTypeSummaryWinLossService summaryService,
            SiteWinLossService siteWinLossService)
        {
            _summaryService = summaryService;
            _siteService = siteWinLossService;
        }

        public VirtualSportsSportTypeWinLossSummary Summary(NumberGameQuery query)
        {
            var criteria = new VirtualSportsSportTypeSummaryWinLossCriteria
            {
                StartDate = query.StartDate,
                EndDate = query.EndDate
            };

            return ModelState.IsValid
                ? _summaryService.Query(criteria)
                : null;
        }
    }
}
