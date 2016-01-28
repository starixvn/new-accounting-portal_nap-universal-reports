using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface SiteWinLossService
    {
        SiteWinLoss Query(WinLossCriteria criteria);
    }
}