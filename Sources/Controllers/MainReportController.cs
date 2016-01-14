using NAP.Reports.CompanyWinLoss.Models.Main;
using NAP.Reports.CompanyWinLoss.QueryModels.Main;
using NAP.Reports.CompanyWinLoss.Services.Main;
using System.Web.Http;

namespace NAP.Reports.CompanyWinLoss.Controllers
{
    public class MainController : ApiController
    {
        private IMainService _service;

        public MainController(IMainService service)
        {
            _service = service;
        }

        public MainWinLoss Values(MainQuery query)
        {
            return ModelState.IsValid
                ? _service.Query(query)
                : null;
        }
    }
}
