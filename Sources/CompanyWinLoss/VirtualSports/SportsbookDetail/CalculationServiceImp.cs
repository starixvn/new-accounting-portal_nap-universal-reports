using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail
{
    public class CalculationServiceImp : CalculationService
    {
        private readonly RemotingRefService refService;

        public CalculationServiceImp(RemotingRefService refService)
        {
            this.refService = refService;
        }

        public WinLoss FromRawWinLoss(RawWinLoss rawWinLoss)
        {
            return new WinLoss
            {
                MatchCode = rawWinLoss.MatchCode,
                HomeName = refService.GetTeamName(rawWinLoss.HomeId),
                AwayName = refService.GetTeamName(rawWinLoss.AwayId),
                Commission = rawWinLoss.Commission,
                MemberWinLoss = rawWinLoss.MemberWinLoss,
                RealIncome = rawWinLoss.RealIncome,
                RealTurnover = rawWinLoss.RealTurnover,
                SMAWinLoss = rawWinLoss.SMAWinLoss,
                Margin = CalculateMargin(rawWinLoss.RealTurnover, rawWinLoss.RealIncome)
            };
        }

        public decimal CalculateMargin(decimal turnover, decimal income)
        {
            return turnover > 0 ? income / turnover : 0;
        }

        public WinLoss CalculateSumWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            if (!rawWinLosses.Any())
            {
                return new WinLoss();
            }

            var sumWinLoss = new RawWinLoss
            {
                Commission = rawWinLosses.Sum(r => r.Commission),
                MemberWinLoss = rawWinLosses.Sum(r => r.MemberWinLoss),
                RealIncome = rawWinLosses.Sum(r => r.RealIncome),
                RealTurnover = rawWinLosses.Sum(r => r.RealTurnover),
                SMAWinLoss = rawWinLosses.Sum(r => r.SMAWinLoss)
            };

            return FromRawWinLoss(sumWinLoss);
        }
    }
}