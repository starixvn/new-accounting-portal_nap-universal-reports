using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface IGroupOfSiteService
    {
        GroupOfSiteWinLoss CalculateGroupSiteWinLoss(IEnumerable<RawWinLoss> rawWinLosses);

        GroupOfSiteWinLoss Query(WinLossCriteria criteria);
    }
}