using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface CalculationService
    {
        WinLoss FromRawWinLossByRowName(RawWinLoss rawWinLoss);

        WinLoss FromRawWinLossByGroupName(RawWinLoss rawWinLoss);

        SiteWinLossSummary CalculateSumWinLossSummary(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses);

        SiteWinLossSummary CalculateChargedCommision(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses);

        WinLoss CalculateSumWinLoss(string sumTitle, IEnumerable<RawWinLoss> rawWinLosses);

        IEnumerable<SiteWinLossSummary> CalculateSiteWinLossSummary(IEnumerable<RawWinLoss> rawWinLosses);

        decimal CalculateMargin(decimal turnover, decimal income);

        WinLoss CreateEmptyWinLoss(int id, string name);

        IEnumerable<WinLoss> CalculateRM(IEnumerable<RawWinLoss> rawWinLosses);

        SiteWinLossSummary CalculateSiteWinLossSummary(int groupId, string groupName, IEnumerable<RawWinLoss> rawWinLosses);

        RawWinLoss CalculateSum(IEnumerable<RawWinLoss> winlosses);
    }
}