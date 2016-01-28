using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class LiveCasinoProductSummaryWinLossServiceImp : LiveCasinoProductSummaryWinLossService
    {
        private CalculationService _calculationService;
        private RawWinLossService _rawWinLossService;

        public LiveCasinoProductSummaryWinLossServiceImp(RawWinLossService rawWinLossService, CalculationService calculationService)
        {
            this._rawWinLossService = rawWinLossService;
            this._calculationService = calculationService;
        }

        public LiveCasinoProductSummaryWinLoss Query(WinLossCriteria winLossCriteria)
        {
            return new LiveCasinoProductSummaryWinLoss();
        }
    }
}
