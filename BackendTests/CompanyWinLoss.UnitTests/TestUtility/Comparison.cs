using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.SiteWinLoss;
using UniversalReports.CompanyWinLoss.Products;

namespace UniversalReports.CompanyWinLoss.UnitTests.TestUtility
{
    internal class Comparison
    {
        internal static bool AreEqual(SiteWinLossSummary expected, SiteWinLossSummary model)
        {
            return AreEqual(expected.Total, model.Total)
                && AreEqual(expected.Deposit, model.Deposit)
                && AreEqual(expected.Credit, model.Credit);
        }

        internal static bool AreEqual(WinLoss expected, WinLoss model)
        {
            return expected.Id == model.Id &&
                    expected.Name == model.Name &&
                    expected.MemberWinLoss == model.MemberWinLoss &&
                    expected.SMAWinLoss == model.SMAWinLoss &&
                    expected.Commission == model.Commission &&
                    expected.RealIncome == model.RealIncome &&
                    expected.VirtualIncome == model.VirtualIncome &&
                    expected.RealTurnover == model.RealTurnover &&
                    expected.VirtualTurnover == model.VirtualTurnover &&
                    expected.VarianceIncome == model.VarianceIncome &&
                    expected.RealMargin == model.RealMargin &&
                    expected.VirtualMargin == model.VirtualMargin;
        }

        internal static bool AreEqual(RawWinLoss expected, RawWinLoss model)
        {
            return expected.GroupId == model.GroupId &&
                expected.GroupName == model.GroupName &&
                expected.RowName == model.RowName &&
                    expected.MemberWinLoss == model.MemberWinLoss &&
                    expected.SMAWinLoss == model.SMAWinLoss &&
                    expected.Commission == model.Commission &&
                    expected.RealIncome == model.RealIncome &&
                    expected.VirtualIncome == model.VirtualIncome &&
                    expected.RealTurnover == model.RealTurnover &&
                    expected.VirtualTurnover == model.VirtualTurnover;
        }

        internal static bool AreEqual(List<WinLoss> expected, List<WinLoss> model)
        {
            if (expected.Count != model.Count)
            {
                return false;
            }

            return !expected.Where((t, i) => !AreEqual(t, model[i])).Any();
        }

        internal static bool AreEqual(List<SiteWinLossSummary> expected, List<SiteWinLossSummary> model)
        {
            if (expected.Count != model.Count)
            {
                return false;
            }

            return !expected.Where((t, i) => !AreEqual(t, model[i])).Any();
        }

        internal static bool AreEqual(ProductWinLoss expected, ProductWinLoss model)
        {
            return AreEqual(expected.SportsbookProducts, model.SportsbookProducts)
                && AreEqual(expected.NoneSportsbookProducts, model.NoneSportsbookProducts)
                && AreEqual(expected.GrandTotal, model.GrandTotal);
        }

        internal static bool AreEqual(SportsbookWinLoss expected, SportsbookWinLoss model)
        {
            return AreEqual(expected.Products, model.Products)
                && AreEqual(expected.RM, model.RM);
        }

        internal static bool AreEqual(NoneSportsbookWinloss expected, NoneSportsbookWinloss model)
        {
            return AreEqual(expected.Products, model.Products)
                && AreEqual(expected.Total, model.Total);
        }

        internal static bool AreEqual(SiteWinLossModel expected, SiteWinLossModel model)
        {
            return AreEqual(expected.Sites, model.Sites)
                && AreEqual(expected.Total, model.Total);
        }
    }
}
