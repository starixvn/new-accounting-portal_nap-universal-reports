using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.ActualMemberBet.Bettype;

namespace UniversalReports.ActualMemberBet.UnitTests.Bettype
{
    [TestFixture]
    public class BetTypeActualMemberBetTests
    {
        [Test]
        public void OperatorPlus_TwoBetTypeActualMemberBet_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new BetTypeActualMemberBet
            {
                BettypeName = "Any Bettype 1",
                MemberTurnoverMYOdds = 100,
                BetCount = 2,
                MemberTurnoverRM = 100,
                MemberNetWinLoss = 20,
                HouseRealTurnoverMYOdds = 80,
                HouseVirtualTurnoverMyOdds = 120,
                HouseRealIncome = 80,
                HouseVirtualWinLoss = 50
            };

            var secondObject = new BetTypeActualMemberBet
            {
                BettypeName = "Any Bettype 2",
                MemberTurnoverMYOdds = 150,
                BetCount = 3,
                MemberTurnoverRM = 150,
                MemberNetWinLoss = 50,
                HouseRealTurnoverMYOdds = 100,
                HouseVirtualTurnoverMyOdds = 180,
                HouseRealIncome = 120,
                HouseVirtualWinLoss = 80
            };

            var expectedObject = new BetTypeActualMemberBet
            {
                BettypeName = "Grand Total",
                MemberTurnoverMYOdds = 250,
                BetCount = 5,
                MemberTurnoverRM = 250,
                MemberNetWinLoss = 70,
                HouseRealTurnoverMYOdds = 180,
                HouseVirtualTurnoverMyOdds = 300,
                HouseRealIncome = 200,
                HouseVirtualWinLoss = 130
            };

            // Act
            var sumObject = firstObject + secondObject;

            // Assert
            Assert.That(sumObject, IsDeeplyEqual.To(expectedObject));
        }
    }
}
