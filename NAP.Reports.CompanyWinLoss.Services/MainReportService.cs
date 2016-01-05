using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class MainReportService : IMainReportService
    {
        private IMainReportProductWinLossService _productWinLossService;
        
        private string[] _productNames;

        public MainReportService(IMainReportProductWinLossService productWinLossService, params string [] productNames)
        {
            _productWinLossService = productWinLossService;
            _productNames = productNames;
        }


        public MainReportWinLoss Query(MainReportQuery query)
        {
            return null;
        }
    }
}
