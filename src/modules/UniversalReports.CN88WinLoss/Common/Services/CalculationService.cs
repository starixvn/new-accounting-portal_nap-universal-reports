using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Common.Services
{
    public interface CalculationService
    {
        WinLoss FromRawWinLossByRowName(WinLossRaw rawWinLoss);

        WinLoss CalculateSumWinLoss(string sumTitle, IEnumerable<WinLossRaw> rawWinLosses);

        IEnumerable<WinLoss> CalculateWinLossSummary(IEnumerable<WinLossRaw> rawWinLosses);

        WinLoss CalculateSiteChargedCom(string sumTitle, IEnumerable<WinLossRaw> rawWinLosses);
    }

    public class CalculationServiceImp : CalculationService
    {
        private readonly RemotingRefService refService;

        public CalculationServiceImp(RemotingRefService refService)
        {
            this.refService = refService;
        }

        public WinLoss FromRawWinLossByRowName(WinLossRaw rawWinLoss)
        {
            var winloss = Mapper.Map<WinLoss>(rawWinLoss);
            winloss.Name = GetMatchCode(rawWinLoss.RowName);

            return winloss;
        }

        private WinLossRaw CalculateSum(IEnumerable<WinLossRaw> winlosses)
        {
            if (!winlosses.Any())
            {
                return new WinLossRaw();
            }

            return new WinLossRaw
            {
                GroupId = winlosses.First().GroupId,
                RowName = winlosses.First().RowName,
                GroupName = winlosses.First().GroupName,
                Commission = winlosses.Sum(r => r.Commission),
                MemberWinLoss = winlosses.Sum(r => r.MemberWinLoss),
                RealIncome = winlosses.Sum(r => r.RealIncome),
                VirtualIncome = winlosses.Sum(r => r.VirtualIncome),
                VarianceIncome = winlosses.Sum(r => r.VarianceIncome),
                HeadlineIncome = winlosses.Sum(r => r.HeadlineIncome),
                RealTurnover = winlosses.Sum(r => r.RealTurnover),
                SMAWinLoss = winlosses.Sum(r => r.SMAWinLoss),
                VirtualTurnover = winlosses.Sum(r => r.VirtualTurnover)
            };
        }

        public WinLoss CalculateSumWinLoss(string sumTitle, IEnumerable<WinLossRaw> rawWinLosses)
        {
            var totalRawWinLoss = CalculateSum(rawWinLosses);
            var totalWinLoss = Mapper.Map<WinLoss>(totalRawWinLoss);
            totalWinLoss.Name = sumTitle;

            return totalWinLoss;
        }

        public virtual IEnumerable<WinLoss> CalculateWinLossSummary(IEnumerable<WinLossRaw> rawWinLosses)
        {
            return Mapper.Map<IEnumerable<WinLoss>>(rawWinLosses);
        }

        public virtual WinLoss CalculateSiteChargedCom(string sumTitle, IEnumerable<WinLossRaw> rawWinLosses)
        {
            var nonRMWinLosses = rawWinLosses.Where(r => r.GroupName != "RM" && r.GroupId != 500);
            return CalculateSumWinLoss(sumTitle, nonRMWinLosses);

        }

        public virtual WinLoss CalculateWinLossSummary(int groupId, string groupName, IEnumerable<WinLossRaw> rawWinLosses)
        {

            return rawWinLosses.Any() ? CalculateSumWinLoss(groupName, rawWinLosses) : CreateEmptyWinLoss(groupId, groupName);

        }

        public WinLoss CreateEmptyWinLoss(int id, string name)
        {
            return new WinLoss
            {
                Id = id,
                Name = name
            };
        }

        private string GetMatchCode(string matchCode)
        {
            return string.IsNullOrEmpty(matchCode) ?
                string.Empty :
                refService.GetMatchCode(matchCode);
        }
    }
}