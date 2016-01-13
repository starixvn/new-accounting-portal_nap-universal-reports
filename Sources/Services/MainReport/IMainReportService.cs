using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using System.Threading.Tasks;

namespace NAP.Reports.CompanyWinLoss.Services.MainReport
{
    public interface IMainReportService
    {
        MainReportWinLoss Query(MainReportQuery query);

        Task<MainReportWinLoss> QueryAsync(MainReportQuery query);
    }
}
