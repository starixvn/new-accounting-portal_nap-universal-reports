using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Products
{
    public interface Service
    {
        List<WinLoss> GetRMWinLoss(IEnumerable<WinLossRaw> rawWinLosses);

        ProductGroupWinLoss GetProductGroup(IEnumerable<WinLossRaw> rawWinLosses, string groupName);

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
            var rawNonSportsbookProducts = filteredRawWinLosses.Where(r => !ProductConstant.NameSportsbook.Contains(r.GroupName) && r.GroupName != ProductConstant.RM);
            var rawRMWinLosses = filteredRawWinLosses.Where(r => r.GroupName == ProductConstant.RM);

            var sportsbookProducts = GetProductGroup(rawSportsbookProducts, "Sportsbook Total");
            var nonSportsbookProducts = GetProductGroup(rawNonSportsbookProducts, "Non-Sports Total");
            var sportsbookRMWinLosses = GetRMWinLoss(rawRMWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", filteredRawWinLosses);
            grandTotal = CalculateGrandTotal(grandTotal, sportsbookRMWinLosses);
            var result = new ProductWinLoss
            {
                Sportsbook = sportsbookProducts,
                RM = sportsbookRMWinLosses,
                NonSportsbook = nonSportsbookProducts,
                GrandTotal = grandTotal
            };

            return result;
        }

        public ProductGroupWinLoss GetProductGroup(IEnumerable<WinLossRaw> rawWinLosses, string groupName)
        {
            var products = calculationService.CalculateSiteWinLossSummary(rawWinLosses).ToList();
            var total = calculationService.CalculateSumWinLossSummary(groupName, rawWinLosses);
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

        private static SiteWinLossSummary CalculateGrandTotal(SiteWinLossSummary siteWinLoss, List<WinLoss> rawWinLoss)
        {
            var rawEightRM = rawWinLoss.Where(r => r.Name.Contains("8RM"));
            var rawBARM = rawWinLoss.Where(r => r.Name.Contains("BARM"));
            siteWinLoss.Credit = CalculateGrandTotalProduct(rawEightRM, siteWinLoss.Credit);
            siteWinLoss.Deposit = CalculateGrandTotalProduct(rawBARM, siteWinLoss.Deposit);
            siteWinLoss.Total = CalculateGrandTotalProduct(rawWinLoss, siteWinLoss.Total);

            return siteWinLoss;
        }

        private static WinLoss CalculateGrandTotalProduct(IEnumerable<WinLoss> rawWinLoss, WinLoss winLoss)
        {
            foreach (var item in rawWinLoss)
            {
                winLoss.MemberWinLoss += item.MemberWinLoss;
                winLoss.SMAWinLoss += item.SMAWinLoss;
                winLoss.Commission += item.Commission;
                winLoss.VarianceIncome += item.VarianceIncome;
                winLoss.VirtualIncome += item.VirtualIncome;
                winLoss.RealIncome += item.RealIncome;
                winLoss.AfterExtraPT += item.AfterExtraPT;
                winLoss.ExtraPT += item.ExtraPT;
            }

            return winLoss;
        }
    }
}