using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services.MainReport;
using System.Threading.Tasks;
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

        public async Task<MainReportWinLoss> Values(MainReportQuery query)
        {
            return ModelState.IsValid
                ? await _service.QueryAsync(query)
                : await Task.FromResult<MainReportWinLoss>(null);
        }
    }
}
