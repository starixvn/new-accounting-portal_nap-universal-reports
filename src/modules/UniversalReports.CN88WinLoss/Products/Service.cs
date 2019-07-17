using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UniversalReports.CN88WinLoss.Common.Models;
using UniversalReports.CN88WinLoss.Common.Services;

namespace UniversalReports.CN88WinLoss.Products
{
    public interface Service
    {
        ProductWinLoss Query(QueryModel queryModel);
    }

    public class ServiceImp : Service
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        private readonly PermissionFilterService permissionFilterService;

        public ServiceImp(
            RawWinLossService rawWinLossService,
            PermissionFilterService permissionFilterService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.permissionFilterService = permissionFilterService;
            this.calculationService = calculationService;
        }

        public ProductWinLoss Query(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            var rawWinLosses = rawWinLossService.Query(criteria);
            var filteredRawWinLosses = permissionFilterService.Filter(rawWinLosses, queryModel.Permissions);

            var rawSportsbookProducts = filteredRawWinLosses.Where(r => ProductConstant.NameSportsbook.Contains(r.GroupName));
            var rawNonSportsbookProducts = filteredRawWinLosses.Where(r => !ProductConstant.NameSportsbook.Contains(r.GroupName));

            var sportsbookProducts = GetProductGroup(rawSportsbookProducts, "Sportsbook Total");
            var nonSportsbookProducts = GetProductGroup(rawNonSportsbookProducts, "Non-Sports Total");
            var grandTotal = calculationService.CalculateSumWinLoss("Grand Total", filteredRawWinLosses);
            var result = new ProductWinLoss
            {
                Sportsbook = sportsbookProducts,
                NonSportsbook = nonSportsbookProducts,
                GrandTotal = grandTotal
            };

            return result;
        }

        public ProductGroupWinLoss GetProductGroup(IEnumerable<WinLossRaw> rawWinLosses, string groupName)
        {
            var products = calculationService.CalculateWinLossSummary(rawWinLosses).ToList();
            var total = calculationService.CalculateSumWinLoss(groupName, rawWinLosses);
            return new ProductGroupWinLoss
            {
                Products = products,
                Total = total
            };
        }

        public List<WinLoss> GetRMWinLoss(IEnumerable<WinLossRaw> rawWinLosses)
        {
            return rawWinLosses.Select(r => calculationService.FromRawWinLossByRowName(r)).ToList();
        }
    }
}