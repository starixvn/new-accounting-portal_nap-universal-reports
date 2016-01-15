using NAP.Reports.CompanyWinLoss.Models.Main;
using NAP.Reports.CompanyWinLoss.QueryModels.Main;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using System.Web.Http;

namespace NAP.Reports.CompanyWinLoss.Controllers
{
    public class MainController : ApiController
    {
        private IProductWinLossService _service;

        public MainController(IProductWinLossService service)
        {
            _service = service;
        }

        public MainWinLoss Values(MainQuery query)
        {
            var criteria = new WinLossCriteria
            {
                StartDate = query.StartDate,
                EndDate = query.EndDate
            };

            return ModelState.IsValid
                ? _service.Query(criteria)
                : null;
        }
    }
}
