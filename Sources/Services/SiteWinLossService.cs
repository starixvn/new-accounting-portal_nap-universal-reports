using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface SiteWinLossService
    {
        SiteWinLoss Query(WinLossCriteria criteria);
    }
}