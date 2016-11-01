using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Common.Services
{
    public interface CalculationService
    {
        WinLoss FromRawWinLossByRowName(WinLossRaw rawWinLoss);

        WinLoss FromRawWinLossByGroupName(WinLossRaw rawWinLoss);

        SiteWinLossSummary CalculateSumWinLossSummary(string sumTitle, IEnumerable<WinLossRaw> rawWinLosses);

        SiteWinLossSummary CalculateSiteChargedCom(string sumTitle, IEnumerable<WinLossRaw> rawWinLosses);

        WinLoss CalculateSumWinLoss(string sumTitle, IEnumerable<WinLossRaw> rawWinLosses);

        IEnumerable<SiteWinLossSummary> CalculateSiteWinLossSummary(IEnumerable<WinLossRaw> rawWinLosses);

        decimal CalculateMargin(decimal income, decimal turnover);

        WinLoss CreateEmptyWinLoss(int id, string name);

        IEnumerable<WinLoss> CalculateRM(IEnumerable<WinLossRaw> rawWinLosses);

        SiteWinLossSummary CalculateSiteWinLossSummary(int groupId, string groupName, IEnumerable<WinLossRaw> rawWinLosses);

        WinLossRaw CalculateSum(IEnumerable<WinLossRaw> winlosses);
    }
}