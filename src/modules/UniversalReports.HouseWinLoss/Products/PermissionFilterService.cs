using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Products
{
    public interface PermissionFilterService
    {
        IEnumerable<WinLossRaw> Filter(IEnumerable<WinLossRaw> winLossRaws, IEnumerable<string> permissions);
    }

    public class PermissionFilterServiceImp : PermissionFilterService
    {
        public IEnumerable<WinLossRaw> Filter(IEnumerable<WinLossRaw> winLossRaws, IEnumerable<string> permissions)
        {
            var filteredSportsbook = FilterSportsbook(winLossRaws, permissions);
            var filteredThirdPartyProducts = FilterThirdPartyProducts(filteredSportsbook, permissions);

            return filteredThirdPartyProducts;
        }

        private static IEnumerable<WinLossRaw> FilterSportsbook(IEnumerable<WinLossRaw> winLossRaws, IEnumerable<string> permissions)
        {
            if (permissions.Contains(PermissionKeys.Sportsbook) || permissions.Contains(PermissionKeys.AllProducts))
            {
                return winLossRaws;
            }

            if (permissions.Contains(PermissionKeys.Soccer))
            {
                return winLossRaws.Where(r => ProductConstant.SoccerPermissionProducts.Contains(r.GroupName));
            }

            if (permissions.Contains(PermissionKeys.OtherSports))
            {
                return winLossRaws.Where(r => ProductConstant.OtherSportsPermissionProducts.Contains(r.GroupName));
            }

            return winLossRaws.Where(r => !ProductConstant.NameSportsbook.Contains(r.GroupName) && r.GroupName != ProductConstant.RM);
        }

        private static IEnumerable<WinLossRaw> FilterThirdPartyProducts(IEnumerable<WinLossRaw> winLossRaws, IEnumerable<string> permissions)
        {
            return permissions.Contains(PermissionKeys.ThirdPartyProducts) || permissions.Contains(PermissionKeys.AllProducts)
                ? winLossRaws
                : winLossRaws.Where(r => ProductConstant.NameSportsbook.Contains(r.GroupName) || r.GroupName == ProductConstant.RM);
        }
    }
}
