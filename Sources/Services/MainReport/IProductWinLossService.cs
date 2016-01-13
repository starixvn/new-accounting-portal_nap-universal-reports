using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Threading.Tasks;

namespace NAP.Reports.CompanyWinLoss.Services.MainReport
{
    public interface IProductWinLossService
    {
        ProductWinLoss Query(string productName, MainReportQuery query);

        ProductWinLoss QueryBySource(string productName, BalanceUpSource source);

        Task<ProductWinLoss> QueryAsync(string productName, MainReportQuery query);

        Task<ProductWinLoss> QueryBySourceAsync(string productName, BalanceUpSource source);
    }
}
