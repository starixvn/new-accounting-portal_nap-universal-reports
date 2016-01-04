using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services;
using System.Web.Http;

namespace NAP.Reports.CompanyWinLoss.Controllers
{
    public class MainReportController : ApiController
    {
        private IMainReportService _service;

        public MainReportController(IMainReportService service)
        {
            _service = service;
        }

        public MainReportWinLoss Values(MainReportQuery query)
        {
            return ModelState.IsValid
                ? _service.Query(query)
                : null;
        }
    }
}
