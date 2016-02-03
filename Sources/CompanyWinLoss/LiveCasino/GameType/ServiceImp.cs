using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.LiveCasino.GameType
{
    public class ServiceImp : Service
    {
        private RawService _rawService;
        private CalculationService _calculationService;

        public ServiceImp(RawService rawService, CalculationService calculationService)
        {
            _rawService = rawService;
            _calculationService = calculationService;
        }

        public WinLossModel Query(WinLossCriteria criteria)
        {
            var rawWinLoss = _rawService.Query(criteria);
            var gameTypes = _calculationService.CalculateSiteWinLossSummary(rawWinLoss).ToList();
            var grandTotal = _calculationService.CalculateSumWinLossSummary("Grand Total", rawWinLoss);

            return new WinLossModel
            {
                GameTypes = gameTypes,
                GrandTotal = grandTotal
            };
        }
    }
}
