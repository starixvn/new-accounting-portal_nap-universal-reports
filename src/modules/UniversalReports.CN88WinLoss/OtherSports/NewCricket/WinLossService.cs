using System.Collections.Generic;
using System.Linq;
using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Common.Models;
using UniversalReports.CN88WinLoss.Common.Services;

namespace UniversalReports.CN88WinLoss.OtherSports.NewCricket
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }

    public class WinLossServiceImp : WinLossService
    {
        private const int BetTypeChargedCom = 500;
        private readonly RawWinLossService rawWinLossService;
        private readonly CalculationService calculationService;

        public WinLossServiceImp(RawWinLossService rawWinLossService, CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var rawWinLossChargedCom = from r in rawWinLosses
                                       where r.GroupId == BetTypeChargedCom
                                       select r;
            var rawWinLossNonChargedCom = from r in rawWinLosses
                                          where r.GroupId != BetTypeChargedCom
                                          select r;
            var winLossChargedCom = calculationService.CalculateWinLossSummary(rawWinLossChargedCom);
            var winLossNonChargedCom = calculationService.CalculateWinLossSummary(rawWinLossNonChargedCom);
            var grandTotal = calculationService.CalculateSumWinLoss("Grand Total", rawWinLosses);

            return new WinLossModel
            {
                GrandTotal = grandTotal,
                WinLossChargedCom = CalculateChargedCom(rawWinLosses, winLossChargedCom),
                WinLossNonChargedCom = winLossNonChargedCom.OrderBy(s => s.Name).ToList()
            };
        }

        private ChargeCommissionModel CalculateChargedCom(IEnumerable<WinLossRaw> rawWinLosses, IEnumerable<WinLoss> chargedCommision)
        {
            return new ChargeCommissionModel
            {
                Total = calculationService.CalculateSiteChargedCom("Total", rawWinLosses),
                Winloss = chargedCommision.OrderBy(s => s.Name).ToList()
            };
        }
    }
}