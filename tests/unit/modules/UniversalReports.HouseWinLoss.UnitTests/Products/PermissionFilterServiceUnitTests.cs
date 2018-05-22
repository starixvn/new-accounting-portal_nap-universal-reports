using System.Collections.Generic;
using System.Linq;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Products;

namespace UniversalReports.HouseWinLoss.UnitTests.Products
{
    public class PermissionFilterServiceUnitTests
    {
        [Test]
        public void Filter_PermissionAll_ReturnsAllData()
        {
            // Arrage
            var winLossRaws = CreateWinLossRawTestCases();
            var permissions = new string[] { "HouseWinLossByProducts_AllProducts" };

            // Act
            var service = new PermissionFilterServiceImp();
            var result = service.Filter(winLossRaws, permissions).ToArray();

            // Assert
            var expected = CreateWinLossRawTestCases().ToArray();
            Assert.That(result, IsDeeplyEqual.To(expected));
        }

        [Test]
        public void Filter_PermissionSportsbook_ReturnsOnlySportsbookData()
        {
            // Arrage
            var winLossRaws = CreateWinLossRawTestCases();
            var permissions = new string[] { "HouseWinLossByProducts_Sportsbook" };

            // Act
            var service = new PermissionFilterServiceImp();
            var result = service.Filter(winLossRaws, permissions).ToArray();

            // Assert
            var expected = CreateOnlySportsbookWinLossRaw().ToArray();
            Assert.That(result, IsDeeplyEqual.To(expected));
        }

        [Test]
        public void Filter_ThirdPartyProducts_ReturnsOnlyThirdPartyProductData()
        {
            // Arrage
            var winLossRaws = CreateWinLossRawTestCases();
            var permissions = new string[] { "HouseWinLossByProducts_ThirdPartyProducts" };

            // Act
            var service = new PermissionFilterServiceImp();
            var result = service.Filter(winLossRaws, permissions).ToArray();

            // Assert
            var expected = CreateOnlyThirdPartyWinLossRaw().ToArray();
            Assert.That(result, IsDeeplyEqual.To(expected));
        }

        [Test]
        public void Filter_NoPermission_ReturnsEmptyData()
        {
            // Arrage
            var winLossRaws = CreateWinLossRawTestCases();
            var permissions = new string[0];

            // Act
            var service = new PermissionFilterServiceImp();
            var result = service.Filter(winLossRaws, permissions).ToArray();

            // Assert
            var expected = new WinLossRaw[0];
            Assert.That(result, IsDeeplyEqual.To(expected));
        }

        private IEnumerable<WinLossRaw> CreateWinLossRawTestCases()
        {
            yield return CreateWinLossRaw("Soccer");
            yield return CreateWinLossRaw("Metric Gaming - Superlive");
            yield return CreateWinLossRaw("Other Sports");
            yield return CreateWinLossRaw("Parlay");
            yield return CreateWinLossRaw("RM");
            yield return CreateWinLossRaw("Number Game");
            yield return CreateWinLossRaw("Virtual Sports");
        }

        private IEnumerable<WinLossRaw> CreateOnlySportsbookWinLossRaw()
        {
            yield return CreateWinLossRaw("Soccer");
            yield return CreateWinLossRaw("Other Sports");
            yield return CreateWinLossRaw("Parlay");
            yield return CreateWinLossRaw("RM");
        }

        private IEnumerable<WinLossRaw> CreateOnlyThirdPartyWinLossRaw()
        {
            yield return CreateWinLossRaw("Metric Gaming - Superlive");
            yield return CreateWinLossRaw("Number Game");
            yield return CreateWinLossRaw("Virtual Sports");
        }

        private WinLossRaw CreateWinLossRaw(string groupName)
        {
            return new WinLossRaw
            {
                GroupName = groupName
            };
        }
    }
}