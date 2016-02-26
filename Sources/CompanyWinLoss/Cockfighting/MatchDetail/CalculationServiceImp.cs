using System;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public class CalculationServiceImp : CalculationService
    {
        private RemotingRefService refService;

        public CalculationServiceImp(RemotingRefService refService)
        {
            this.refService = refService;
        }

        public decimal CalulationMargin(decimal realIncome, decimal turnOver)
        {
            return turnOver == 0 ? 0 : realIncome / turnOver;
        }

        public IEnumerable<ArenaWinLoss> Arenas(IEnumerable<RawWinLoss> rawWinLoss)
        {
            var groups = rawWinLoss.GroupBy(x => x.ArenaId).Distinct();
            return from @group in groups
                   select CalculationArena(@group, Convert.ToInt32(@group.Key));
        }

        public ArenaWinLoss CalculationArena(IEnumerable<RawWinLoss> rawWinLoss, int arenaId)
        {
            var rawWinLossTotal = CalculationSum(rawWinLoss);
            var total = FromRawWinLoss(rawWinLossTotal);
            var matches = from item in rawWinLoss
                          select FromRawWinLoss(item);

            return new ArenaWinLoss
            {
                ArenaName = refService.GetLeagueName(arenaId),
                Matches = matches.ToList(),
                Total = total
            };
        }

        public RawWinLoss CalculationSum(IEnumerable<RawWinLoss> rawWinLoss)
        {
            if (!rawWinLoss.Any())
            {
                return new RawWinLoss();
            }

            return new RawWinLoss
            {
                FightNo = string.Empty,
                ArenaId = 0,
                HomeName = string.Empty,
                AwayName = string.Empty,
                Commission = rawWinLoss.Sum(r => r.Commission),
                MemberWinLoss = rawWinLoss.Sum(r => r.MemberWinLoss),
                RealIncome = rawWinLoss.Sum(r => r.RealIncome),
                RealTurnover = rawWinLoss.Sum(r => r.RealTurnover),
                SMAWinLoss = rawWinLoss.Sum(r => r.SMAWinLoss)
            };
        }

        public WinLoss FromRawWinLoss(RawWinLoss winLoss)
        {
            return new WinLoss
            {
                FightNo = winLoss.FightNo,
                ArenaId = winLoss.ArenaId,
                HomeName = winLoss.HomeName,
                AwayName = winLoss.AwayName,
                MemberWinLoss = winLoss.MemberWinLoss,
                SMAWinLoss = winLoss.SMAWinLoss,
                Commission = winLoss.Commission,
                RealIncome = winLoss.RealIncome,
                RealTurnover = winLoss.RealTurnover,
                Margin = CalulationMargin(winLoss.RealIncome, winLoss.RealTurnover)
            };
        }
    }
}
