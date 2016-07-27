using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Configuration;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class ServiceImp : Service
    {
        private readonly RawWinLossService rawWinLossService;

        private readonly CalculationService calculationService;

        public ServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            this.rawWinLossService = rawWinLossService;
            this.calculationService = calculationService;
        }

        public ProductWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLosses = rawWinLossService.Query(criteria);

            var rawSportsbookProducts = rawWinLosses.Where(r => Constants.NameSportsbook.Contains(r.GroupName));
            var rawNonSportsbookProducts = rawWinLosses.Where(r => !Constants.NameSportsbook.Contains(r.GroupName) && r.GroupName != Constants.RM);
            var rawRMWinLosses = rawWinLosses.Where(r => r.GroupName == Constants.RM);

            var sportsbookProducts = GetProductGroup(rawSportsbookProducts, "Sportsbook Total");
            var nonSportsbookProducts = GetProductGroup(rawNonSportsbookProducts, "Non-Sports Total");
            var sportsbookRMWinLosses = GetRMWinLoss(rawRMWinLosses);
            var grandTotal = calculationService.CalculateSumWinLossSummary("Grand Total", rawWinLosses);
            grandTotal = CalculateGrandTotal(grandTotal, sportsbookRMWinLosses);
            return new ProductWinLoss
            {
                Sportsbook = sportsbookProducts,
                RM = sportsbookRMWinLosses,
                NonSportsbook = nonSportsbookProducts,
                GrandTotal = grandTotal
            };
        }

        public ProductGroupWinLoss GetProductGroup(IEnumerable<RawWinLoss> rawWinLosses, string groupName)
        {
            var products = calculationService.CalculateSiteWinLossSummary(rawWinLosses).ToList();
            var total = calculationService.CalculateSumWinLossSummary(groupName, rawWinLosses);
            return new ProductGroupWinLoss
            {
                Products = products,
                Total = total
            };
        }

        public List<WinLoss> GetRMWinLoss(IEnumerable<RawWinLoss> rawWinLosses)
        {
            return rawWinLosses.Select(r => calculationService.FromRawWinLossByRowName(r)).ToList();
        }

        public SiteWinLossSummary CalculateGrandTotal(SiteWinLossSummary siteWinLoss, List<WinLoss> rawWinLoss)
        {
            var rawEightRM = rawWinLoss.Where(r => r.Name.Contains("8RM"));
            var rawBARM = rawWinLoss.Where(r => r.Name.Contains("BARM"));
            siteWinLoss.Credit = CalculateGrandTotalProduct(rawEightRM, siteWinLoss.Credit);
            siteWinLoss.Deposit = CalculateGrandTotalProduct(rawBARM, siteWinLoss.Deposit);
            siteWinLoss.Total = CalculateGrandTotalProduct(rawWinLoss, siteWinLoss.Total);

            return siteWinLoss;
        }

        public WinLoss CalculateGrandTotalProduct(IEnumerable<WinLoss> rawWinLoss, WinLoss winLoss)
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