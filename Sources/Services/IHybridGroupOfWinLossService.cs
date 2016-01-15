using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface IHybridGroupOfWinLossService
    {
        HybridGroupOfWinLoss Query(WinLossCriteria criteria);
    }
}