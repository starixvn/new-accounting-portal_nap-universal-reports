using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface IMainReportSportsbookService
    {
        ProductWinLoss Query(MainReportQuery query);
    }
}
