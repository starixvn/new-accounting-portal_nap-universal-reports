using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;

namespace NAP.Reports.CompanyWinLoss.Services.MainReport
{
    public interface IMainReportService
    {
        MainReportWinLoss Query(MainReportQuery query);
    }
}
