using System.Web.Http;
using Criteria = UniversalReports.CompanyWinLoss.VirtualSports.Summary.Criteria;
using QueryModel = UniversalReports.CompanyWinLoss.NumberGame.Summary.QueryModel;
using Service = UniversalReports.CompanyWinLoss.VirtualSports.Summary.Service;
using WinLossModel = UniversalReports.CompanyWinLoss.VirtualSports.Summary.WinLossModel;

namespace UniversalReports.CompanyWinLoss.VirtualSports
{
    public class VirtualSportsController : ApiController
    {
        private readonly Service _summaryService;

        public VirtualSportsController(
            Service summaryService)
        {
            _summaryService = summaryService;
        }

        public WinLossModel Summary(QueryModel queryModel)
        {
            var criteria = new Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate
            };

            return ModelState.IsValid
                ? _summaryService.Query(criteria)
                : null;
        }
    }
}
