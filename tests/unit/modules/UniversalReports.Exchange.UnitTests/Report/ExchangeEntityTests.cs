using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.Exchange.Report;

namespace UniversalReports.Exchange.UnitTests.Report
{
    [TestFixture]
    public class ExchangeEntityTests
    {
        [Test]
        public void OperatorPlus_TwoBetTypeModels_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new ExchangeEntity
            {
                Name = "Any name",
                MemberCount = 1,
                BetCount = 1,
                TurnOver = 22,
                MemberWinLoss = 10,
                MemberCommission = 1,
                MemberTotal = 11,
                LicenseeWinLoss = 6,
                LicenseeCommission = 1,
                LicenseeTotal = 7,
                CompanyWinLoss = 15,
                CompanyCommission = 2,
                PayToSupplier = 1,
                CompanyNetIncome = 18
            };

            var secondObject = new ExchangeEntity
            {
                Name = "Any name 1",
                MemberCount = 2,
                BetCount = 2,
                TurnOver = 25,
                MemberWinLoss = 5,
                MemberCommission = 1,
                MemberTotal = 6,
                LicenseeWinLoss = 8,
                LicenseeCommission = 1,
                LicenseeTotal = 9,
                CompanyWinLoss = 17,
                CompanyCommission = 2,
                PayToSupplier = 1,
                CompanyNetIncome = 20
            };

            var expectedObject = new ExchangeEntity
            {
                Name = "Grand Total",
                MemberCount = 3,
                BetCount = 3,
                TurnOver = 47,
                MemberWinLoss = 15,
                MemberCommission = 2,
                MemberTotal = 17,
                LicenseeWinLoss = 14,
                LicenseeCommission = 2,
                LicenseeTotal = 16,
                CompanyWinLoss = 32,
                CompanyCommission = 4,
                PayToSupplier = 2,
                CompanyNetIncome = 38
            };

            // Act
            var sumObject = firstObject + secondObject;

            // Assert
            Assert.That(sumObject, IsDeeplyEqual.To(expectedObject));
        }
    }
}
