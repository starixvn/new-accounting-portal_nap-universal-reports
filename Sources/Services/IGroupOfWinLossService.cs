using System.Collections.Generic;
using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface IGroupOfWinLossService
    {
        GroupOfWinLoss CalculateGroupOfWinLoss(IEnumerable<RawWinLoss> rawWinLosses);

        GroupOfWinLoss Query(WinLossCriteria criteria);
    }
}