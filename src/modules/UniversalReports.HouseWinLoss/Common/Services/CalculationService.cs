using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        WinLoss CreateEmptyWinLoss(int id, string name);

        IEnumerable<WinLoss> CalculateRM(IEnumerable<WinLossRaw> rawWinLosses);

        SiteWinLossSummary CalculateSiteWinLossSummary(int groupId, string groupName, IEnumerable<WinLossRaw> rawWinLosses);

        WinLossRaw CalculateSum(IEnumerable<WinLossRaw> winlosses);
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
            var winloss = FromRawWinLoss(rawWinLoss);
            winloss.Name = GetMatchCode(rawWinLoss.RowName);

            return winloss;
        }

        public WinLoss FromRawWinLossByGroupName(WinLossRaw rawWinLoss)
        {
            var winloss = FromRawWinLoss(rawWinLoss);
            winloss.Name = rawWinLoss.GroupName;
            return winloss;
        }

        private static WinLoss FromRawWinLoss(WinLossRaw rawWinLoss)
        {
            var winLoss = Mapper.Map<WinLoss>(rawWinLoss);
            winLoss.Id = rawWinLoss.GroupId;
            return winLoss;
        }

        public WinLossRaw CalculateSum(IEnumerable<WinLossRaw> winlosses)
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
                ExtraPT = winlosses.Sum(r => r.ExtraPT),
                AfterExtraPT = winlosses.Sum(r => r.AfterExtraPT),
                RealTurnover = winlosses.Sum(r => r.RealTurnover),
                SMAWinLoss = winlosses.Sum(r => r.SMAWinLoss),
                VirtualTurnover = winlosses.Sum(r => r.VirtualTurnover)
            };
        }

        public WinLoss CalculateSumWinLoss(string sumTitle, IEnumerable<WinLossRaw> rawWinLosses)
        {
            var totalRawWinLoss = CalculateSum(rawWinLosses);
            var totalWinLoss = FromRawWinLossByGroupName(totalRawWinLoss);
            totalWinLoss.Name = sumTitle;

            return totalWinLoss;
        }

        public virtual SiteWinLossSummary CalculateSumWinLossSummary(string sumTitle, IEnumerable<WinLossRaw> rawWinLosses)
        {
            var nonRMWinLosses = rawWinLosses.Where(r => r.GroupName != "RM");
            var grandTotal = new SiteWinLossSummary
            {
                Credit = SumCreditGrandTotalWinLoss(nonRMWinLosses),
                Deposit = SumDepositGrandTotalWinLoss(nonRMWinLosses),
                Total = CalculateSumWinLoss(sumTitle, nonRMWinLosses)
            };

            return grandTotal;
        }

        public virtual SiteWinLossSummary CalculateSiteChargedCom(string sumTitle, IEnumerable<WinLossRaw> rawWinLosses)
        {
            var nonRMWinLosses = rawWinLosses.Where(r => r.GroupName != "RM" && r.GroupId != 500);
            var grandTotal = new SiteWinLossSummary
            {
                Credit = SumCreditGrandTotalWinLoss(nonRMWinLosses),
                Deposit = SumDepositGrandTotalWinLoss(nonRMWinLosses),
                Total = CalculateSumWinLoss(sumTitle, nonRMWinLosses)
            };

            return grandTotal;
        }

        private WinLoss SumCreditGrandTotalWinLoss(IEnumerable<WinLossRaw> rawWinLosses)
        {
            var creditData = rawWinLosses.Where(r => r.RowName == "Credit");
            var sumData = CalculateSum(creditData);

            var winloss = FromRawWinLossByRowName(sumData);
            winloss.Name = "Credit";

            return winloss;
        }

        private WinLoss SumDepositGrandTotalWinLoss(IEnumerable<WinLossRaw> rawWinLosses)
        {
            var depositData = rawWinLosses.Where(r => r.RowName == "Deposit");
            var sumData = CalculateSum(depositData);

            var winloss = FromRawWinLossByRowName(sumData);
            winloss.Name = "Deposit";

            return winloss;
        }

        public virtual IEnumerable<SiteWinLossSummary> CalculateSiteWinLossSummary(IEnumerable<WinLossRaw> rawWinLosses)
        {
            var groups = rawWinLosses
                            .Where(r => r.GroupName != "RM")
                            .Select(r => new { Name = r.GroupName, Id = r.GroupId })
                            .Distinct();
            return from @group in groups
                   let rawGroupWinLosses = rawWinLosses.Where(r => r.GroupId == @group.Id && r.GroupName == @group.Name).ToArray()
                   select CalculateSiteWinLossSummary(@group.Id, @group.Name, rawGroupWinLosses);
        }

        public virtual SiteWinLossSummary CalculateSiteWinLossSummary(int groupId, string groupName, IEnumerable<WinLossRaw> rawWinLosses)
        {
            var rawCreditWinLoss = rawWinLosses.FirstOrDefault(r => r.RowName == "Credit");
            var rawDepositWinLoss = rawWinLosses.FirstOrDefault(r => r.RowName == "Deposit");

            var creditWinLoss = rawCreditWinLoss == null ? CreateEmptyWinLoss(groupId, "Credit") : FromRawWinLossByRowName(rawCreditWinLoss);
            var depositWinLoss = rawDepositWinLoss == null ? CreateEmptyWinLoss(groupId, "Deposit") : FromRawWinLossByRowName(rawDepositWinLoss);
            var totalWinLoss = rawWinLosses.Any() ? CalculateSumWinLoss(groupName, rawWinLosses) : CreateEmptyWinLoss(groupId, groupName);

            return new SiteWinLossSummary
            {
                Credit = creditWinLoss,
                Deposit = depositWinLoss,
                Total = totalWinLoss
            };
        }

        public WinLoss CreateEmptyWinLoss(int id, string name)
        {
            return new WinLoss
            {
                Id = id,
                Name = name
            };
        }

        public IEnumerable<WinLoss> CalculateRM(IEnumerable<WinLossRaw> rawWinLosses)
        {
            return rawWinLosses.Where(r => r.GroupName == "RM")
                .Select(FromRawWinLossByRowName);
        }

        private string GetMatchCode(string matchCode)
        {
            return string.IsNullOrEmpty(matchCode) ?
                string.Empty :
                refService.GetMatchCode(matchCode);
        }
    }
}