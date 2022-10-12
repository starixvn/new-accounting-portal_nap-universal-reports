using AutoMapper;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.ProductBetType
{
    public interface Service
    {
        ProductBetTypeWinLoss Query(QueryModel queryModel);
    }

    public class ServiceImp : Service
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public ServiceImp(RawWinLossService rawWinLossService, CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public ProductBetTypeWinLoss Query(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);

            var rawBetTypes = rawWinLossService.Query(criteria);
           
            var betTypes = calculationService.CalculateBetTypes(rawBetTypes);

            var grandTotal = calculationService.CalculateSumWinLoss("Grand Total", rawBetTypes);

            return new ProductBetTypeWinLoss
            {
                BetTypes = betTypes,
                GrandTotal = grandTotal
            };
        }
    }
}
