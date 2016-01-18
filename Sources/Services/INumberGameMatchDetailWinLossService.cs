using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface INumberGameMatchDetailWinLossService
    {
        NumberGameMatchDetailWinLoss Query(WinLossCriteria criteria);
    }
}