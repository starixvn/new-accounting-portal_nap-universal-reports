using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface SiteService
    {
        SiteWinLossModel Query(WinLossCriteria criteria);
    }
}