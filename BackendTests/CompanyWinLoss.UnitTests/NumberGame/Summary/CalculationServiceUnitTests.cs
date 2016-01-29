using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.NumberGame.Summary;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;
using CommonModels = UniversalReports.CompanyWinLoss.Common.Models;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.NumberGame.Summary
{
    public class CalculationServiceUnitTests
    {
        private CommonServices.CalculationService _commonCalculationService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _commonCalculationService = new CommonServices.CalculationServiceImp();
        }

        [Test]
        public void CalculateSumWinLossSummary_TwoGroups_ReturnRightGrandTotal()
        {
            // Arrange   
            var expectedGrandTotal = CreateExpectedGrandTotal();
            var fakeData = CreateFakeRawWinLoss();

            // Act 
            var service = new CalculationServiceImp(_commonCalculationService);
            var result = service.CalculateSumWinLossSummary("Grand Total", fakeData);

            // Assert
            var equal = WinLossComparision.AreTwoSiteWinLossSummaryEqual(expectedGrandTotal, result);
            Assert.True(equal);
        }

        private CommonModels.SiteWinLossSummary CreateExpectedGrandTotal()
        {
            return new CommonModels.SiteWinLossSummary
            {
                Credit = WinLossFactory.CreateWinLoss(1, "Credit", 200, 220, 20, 1000, 1200, -200, 1800, 2000, 1000m / 1800, 1200m / 2000),
                Deposit = WinLossFactory.CreateWinLoss(1, "Deposit", 220, 240, 22, 1100, 1320, -220, 1980, 2200, 1100m / 1980, 1320m / 2200),
                Total = WinLossFactory.CreateWinLoss(1, "Grand Total", 420, 460, 42, 2100, 2520, -420, 3780, 4200, 2100m / 3780, 2520m / 4200)
            };
        }

        private IEnumerable<RawWinLoss> CreateFakeRawWinLoss()
        {
            var group1 = CreateFakeRawGroupWinLoss(1, "Group 1");
            var group2 = CreateFakeRawGroupWinLoss(2, "Group 2");

            return (new List<List<RawWinLoss>> { group1, group2 })
                    .SelectMany(l => l)
                    .ToList();
        }

        private List<RawWinLoss> CreateFakeRawGroupWinLoss(int groupId, string groupName)
        {
            var creditWinLoss = NumberGameWinLossFactory.CreateRawWinLoss(groupId, groupName, "Credit", true, 100, 110, 10, 500, 600, 900, 1000);
            var depositWinLoss = NumberGameWinLossFactory.CreateRawWinLoss(groupId, groupName, "Deposit", true, 110, 120, 11, 550, 660, 990, 1100);

            return new List<RawWinLoss> { creditWinLoss, depositWinLoss };
        }

        [Test]
        public void CalculateSiteWinLossSummary_MissingCreditAndDeposit_ReturnEmptySiteWinLoss()
        {
            // Arrange   
            var expectedGroup = CreateEmptySiteWinLoss();
            var fakeData = new List<RawWinLoss>();

            // Act 
            var service = new CalculationServiceImp(_commonCalculationService);
            var result = service.CalculateSiteWinLossSummary(1, "Group 1", fakeData);

            // Assert
            var equal = WinLossComparision.AreTwoSiteWinLossSummaryEqual(expectedGroup, result);

            Assert.True(equal);
        }

        private CommonModels.SiteWinLossSummary CreateEmptySiteWinLoss()
        {
            return new CommonModels.SiteWinLossSummary
            {
                Credit = WinLossFactory.CreateWinLoss(1, "Credit", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                Deposit = WinLossFactory.CreateWinLoss(1, "Deposit", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                Total = WinLossFactory.CreateWinLoss(1, "Group 1", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
            };
        }

        [Test]
        public void CalculateSiteWinLossSummary_TwoGroups_ReturnRightGroups()
        {
            // Arrange   
            var expectedGroups = CreateExpectedGroups();
            var fakeData = CreateFakeRawWinLoss();

            // Act 
            var service = new CalculationServiceImp(_commonCalculationService);
            var result = service.CalculateSiteWinLossSummary(fakeData).ToList();

            // Assert
            var equal1 = WinLossComparision.AreTwoSiteWinLossSummaryEqual(expectedGroups[0], result[0]);
            var equal2 = WinLossComparision.AreTwoSiteWinLossSummaryEqual(expectedGroups[1], result[1]);
            Assert.True(equal1);
            Assert.True(equal2);
        }

        private List<CommonModels.SiteWinLossSummary> CreateExpectedGroups()
        {
            var group1 = CreateExpectedGroup(1, "Group 1");
            var group2 = CreateExpectedGroup(2, "Group 2");

            return new List<CommonModels.SiteWinLossSummary> { group1, group2 };
        }

        private CommonModels.SiteWinLossSummary CreateExpectedGroup(int groupId, string groupName)
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss(groupId, "Credit", 100, 110, 10, 500, 600, -100, 900, 1000, 500m / 900, 600m / 1000);
            var depositWinLoss = WinLossFactory.CreateWinLoss(groupId, "Deposit", 110, 120, 11, 550, 660, -110, 990, 1100, 550m / 990, 660m / 1100);
            var totalWinLoss = WinLossFactory.CreateWinLoss(groupId, groupName, 210, 230, 21, 1050, 1260, -210, 1890, 2100, 1050m / 1890, 1260m / 2100);

            return new CommonModels.SiteWinLossSummary { Credit = creditWinLoss, Deposit = depositWinLoss, Total = totalWinLoss };
        }
    }
}
