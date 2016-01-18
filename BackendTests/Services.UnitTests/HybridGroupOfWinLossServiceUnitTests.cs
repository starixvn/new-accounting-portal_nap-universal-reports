//using NAP.Reports.CompanyWinLoss.Models;
//using NAP.Reports.CompanyWinLoss.Services.Criteria;
//using NAP.Reports.CompanyWinLoss.Services.Models;
//using NSubstitute;
//using NUnit.Framework;
//using System.Collections.Generic;

//namespace NAP.Reports.CompanyWinLoss.Services.UnitTests
//{
//    public class HybridGroupOfWinLossServiceUnitTests
//    {
//        [Test]
//        [Category("ServiceUnitTests")]
//        public void Calculate_ReturnRightHybridGroupOfWinLoss()
//        {
//            // Arrange   
//            var expectedMainWinLoss = CreateExpectedHybridGroupOfWinLoss();
//            var calculationService = new CalculationService();
//            var rawWinLossService = Substitute.For<IRawWinLossService>();
//            var fakeData = CreateFakeRawWinLoss();
//            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

//            // Act 
//            var service = new HybridGroupOfWinLossService(rawWinLossService, calculationService);
//            var result = service.Query(Arg.Any<WinLossCriteria>());

//            // Assert
//            var equal = WinLossComparision.AreTwoHybridGroupOfWinLossEqual(expectedMainWinLoss, result);
//            Assert.True(equal);
//        }

//        private HybridGroupOfWinLoss CreateExpectedHybridGroupOfWinLoss()
//        {
//            var expectedWinLosses = CreateExpectedWinLosses();
//            var expectedGrandTotal = CreateExpectedGrandTotal();

//            return new HybridGroupOfWinLoss
//            {
//                GrandTotal = expectedGrandTotal,
//                WinLosses = expectedWinLosses,
//            };
//        }

//        private List<GroupOfWinLoss> CreateExpectedWinLosses()
//        {
//            var group1 = CreateExpectedGroupOfWinLosses(1, "Group 1");
//            var group2 = CreateExpectedGroupOfWinLosses(2, "Group 2");

//            return new List<GroupOfWinLoss> { group1, group2 };
//        }

//        private GroupOfWinLoss CreateExpectedGroupOfWinLosses(int groupId, string groupName)
//        {
//            var winloss1 = WinLossFactory.CreateWinLoss(groupId, "WinLoss 1", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m);
//            var winloss2 = WinLossFactory.CreateWinLoss(groupId, "WinLoss 2", 110, 120, 11, 550, 660, -110, 990, 1100, 5m / 9, 0.6m);

//            return new GroupOfWinLoss
//            {
//                Name = groupName,
//                WinLosses = new List<WinLoss> { winloss1, winloss2 }
//            };
//        }

//        private List<RawWinLoss> CreateFakeRawWinLoss()
//        {
//            return new List<RawWinLoss>
//            {
//                WinLossFactory.CreateRawWinLoss(1, "Group 1", "WinLoss 1", 100, 110, 10, 500, 600, 900, 1000),
//                WinLossFactory.CreateRawWinLoss(1, "Group 1", "WinLoss 2", 110, 120, 11, 550, 660, 990, 1100),
//                WinLossFactory.CreateRawWinLoss(2, "Group 2", "WinLoss 1", 100, 110, 10, 500, 600, 900, 1000),
//                WinLossFactory.CreateRawWinLoss(2, "Group 2", "WinLoss 2", 110, 120, 11, 550, 660, 990, 1100)
//            };
//        }

//        private WinLoss CreateExpectedGrandTotal()
//        {
//            return WinLossFactory.CreateWinLoss(0, "Total", 420, 460, 42, 2100, 2520, -420, 3780, 4200, 5m / 9, 0.6m);
//        }
//    }
//}
