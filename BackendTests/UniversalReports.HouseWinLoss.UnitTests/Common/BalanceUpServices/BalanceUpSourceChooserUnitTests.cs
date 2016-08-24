using NSubstitute;
using NUnit.Framework;
using System;
using UniversalReports.HouseWinLoss.Common.BalanceUpServices;
using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.BalanceUpServices
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class BalanceUpSourceChooserUnitTests
    {
        private static readonly BalanceUpRange BalanceUpRange = new BalanceUpRange
        {
            BalanceUpDate = new DateTime(2015, 06, 01),
            MoveBetsDate = new DateTime(2015, 09, 01)
        };

        [Test]
        public void Determine_NormalMode_StartDateAfterMoveBetsDate_ReturnsBetTransSource()
        {
            // Arrange
            var criteria = new WinLossCriteria
            {
                NormalMode = true,
                StartDate = new DateTime(2015, 10, 01),
                EndDate = new DateTime(2015, 11, 01)
            };

            var balanceUpService = Substitute.For<BalanceUpService>();
            balanceUpService.Query().Returns(BalanceUpRange);
            var balancerUpSourceChooser = new BalanceUpSourceChooserImp(balanceUpService);

            // Act
            var result = balancerUpSourceChooser.Determine(criteria);

            // Assert
            Assert.AreEqual("BetTrans", result);
        }

        [Test]
        public void Determine_NormalMode_StartDateBetweenBalanceUpRange_ReturnsBetTrans14Source()
        {
            // Arrange
            var criteria = new WinLossCriteria
            {
                NormalMode = true,
                StartDate = new DateTime(2015, 07, 01),
                EndDate = new DateTime(2015, 11, 01)
            };

            var balanceUpService = Substitute.For<BalanceUpService>();
            balanceUpService.Query().Returns(BalanceUpRange);
            var balancerUpSourceChooser = new BalanceUpSourceChooserImp(balanceUpService);

            // Act
            var result = balancerUpSourceChooser.Determine(criteria);

            // Assert
            Assert.AreEqual("BetTrans14", result);
        }

        [Test]
        public void Determine_NormalMode_StartDateBeforeBalanceUpRange_ReturnsWarehouseSource()
        {
            // Arrange
            var criteria = new WinLossCriteria
            {
                NormalMode = true,
                StartDate = new DateTime(2015, 05, 01),
                EndDate = new DateTime(2015, 08, 01)
            };

            var balanceUpService = Substitute.For<BalanceUpService>();
            balanceUpService.Query().Returns(BalanceUpRange);
            var balancerUpSourceChooser = new BalanceUpSourceChooserImp(balanceUpService);

            // Act
            var result = balancerUpSourceChooser.Determine(criteria);

            // Assert
            Assert.AreEqual("Warehouse", result);
        }

        [Test]
        public void Determine_HistoryMode_ReturnWarehouseSource()
        {
            // Arrange
            var criteria = new WinLossCriteria
            {
                NormalMode = false,
                StartDate = new DateTime(2015, 03, 01),
                EndDate = new DateTime(2015, 11, 01)
            };

            var balanceUpService = Substitute.For<BalanceUpService>();
            balanceUpService.Query().Returns(BalanceUpRange);
            var balancerUpSourceChooser = new BalanceUpSourceChooserImp(balanceUpService);

            // Act
            var result = balancerUpSourceChooser.Determine(criteria);

            // Assert          
            Assert.AreEqual("Warehouse", result);
        }
    }
}
