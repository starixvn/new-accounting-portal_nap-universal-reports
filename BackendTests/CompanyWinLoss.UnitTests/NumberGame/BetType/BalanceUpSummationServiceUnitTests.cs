using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.NumberGame.BetType;

namespace UniversalReports.CompanyWinLoss.UnitTests.NumberGame.BetType
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class BalanceUpSummationServiceUnitTests
    {
        [Test]
        public void CalculateSum_TwoArrayWithTwoRawWinLosses_ReturnsRightSumValue()
        {
            var expectedSum = new List<RawWinLoss>
            {
                NumberGameWinLossFactory.CreateRawWinLoss(1, "BetType1", "Deposit", true, 210, 230, 21, 1050, 1260, 1890, 2100),
                NumberGameWinLossFactory.CreateRawWinLoss(1, "BetType1", "Credit", true, 210, 230, 21, 1050, 1260, 1890, 2100)
            };

            var deposit1 = NumberGameWinLossFactory.CreateRawWinLoss(1, "BetType1", "Deposit", true, 100, 110, 10, 500, 600, 900, 1000);
            var deposit2 = NumberGameWinLossFactory.CreateRawWinLoss(1, "BetType1", "Deposit", true, 110, 120, 11, 550, 660, 990, 1100);
            var credit1 = NumberGameWinLossFactory.CreateRawWinLoss(1, "BetType1", "Credit", true, 100, 110, 10, 500, 600, 900, 1000);
            var credit2 = NumberGameWinLossFactory.CreateRawWinLoss(1, "BetType1", "Credit", true, 110, 120, 11, 550, 660, 990, 1100);

            var group1 = new[] { deposit1, credit1 };
            var group2 = new[] { deposit2, credit2 };
            var winlosses = new[] { group1, group2 };

            // Act
            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            var result = balanceUpSummationService.CalculateSum(winlosses).ToList();

            // Assert
            var areEqual1 = AreTwoRawWinLossEqual(expectedSum[0], result[0]);
            var areEqual2 = AreTwoRawWinLossEqual(expectedSum[1], result[1]);

            Assert.True(areEqual1);
            Assert.True(areEqual2);
        }

        [Test]
        public void CalculateSum_ArrayWithTwoWinLosses_AndArrayWithOneWinLoss_ReturnsRightSumValue()
        {
            var expectedSum = new List<RawWinLoss>
            {
                NumberGameWinLossFactory.CreateRawWinLoss(1, "BetType1", "Deposit", true, 210, 230, 21, 1050, 1260, 1890, 2100),
                NumberGameWinLossFactory.CreateRawWinLoss(1, "BetType1", "Credit", true, 100, 110, 10, 500, 600, 900, 1000)
            };

            var deposit1 = NumberGameWinLossFactory.CreateRawWinLoss(1, "BetType1", "Deposit", true, 100, 110, 10, 500, 600, 900, 1000);
            var deposit2 = NumberGameWinLossFactory.CreateRawWinLoss(1, "BetType1", "Deposit", true, 110, 120, 11, 550, 660, 990, 1100);
            var credit1 = NumberGameWinLossFactory.CreateRawWinLoss(1, "BetType1", "Credit", true, 100, 110, 10, 500, 600, 900, 1000);

            var group1 = new[] { deposit1, credit1 };
            var group2 = new[] { deposit2 };
            var winlosses = new[] { group1, group2 };

            // Act
            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            var result = balanceUpSummationService.CalculateSum(winlosses).ToList();

            // Assert
            var areEqual1 = AreTwoRawWinLossEqual(expectedSum[0], result[0]);
            var areEqual2 = AreTwoRawWinLossEqual(expectedSum[1], result[1]);

            Assert.True(areEqual1);
            Assert.True(areEqual2);
        }

        internal static bool AreTwoRawWinLossEqual(RawWinLoss first, RawWinLoss second)
        {
            return first.GroupName == second.GroupName &&
                first.RowName == second.RowName &&
                    first.MemberWinLoss == second.MemberWinLoss &&
                    first.SMAWinLoss == second.SMAWinLoss &&
                    first.Commission == second.Commission &&
                    first.RealIncome == second.RealIncome &&
                    first.VirtualIncome == second.VirtualIncome &&
                    first.RealTurnover == second.RealTurnover &&
                    first.VirtualTurnover == second.VirtualTurnover;
        }
    }
}
