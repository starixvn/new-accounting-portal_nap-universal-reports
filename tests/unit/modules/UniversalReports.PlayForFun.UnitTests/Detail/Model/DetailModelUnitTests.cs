using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using UniversalReports.PlayForFun.Detail.Model;

namespace UniversalReports.PlayForFun.UnitTests.Detail.Model
{
    public class DetailModelUnitTests
    {
        [Test]
        public void OperatorPlus_TwoDetailModels_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new DetailModel
            {
                Date = DateTime.Today.AddDays(-1),
                GroupHeadline = "Group Headline 1",
                Site = "Site 1",
                Currency = "Currency 1",
                Super = "Super 1",
                Product = "Product 1",
                MemberRequest = "No",
                Status = "Enabled",
                Username = "User 1",
                CustId = 1,
                WinLoss = 100,
                Turnover = 200,
                BetCount = 2
            };

            var secondObject = new DetailModel
            {
                Date = DateTime.Today.AddDays(-2),
                GroupHeadline = "Group Headline 2",
                Site = "Site 2",
                Currency = "Currency 2",
                Super = "Super 2",
                Product = "Product 2",
                MemberRequest = "No",
                Status = "Disabled",
                Username = "User 2",
                CustId = 2,
                WinLoss = 200,
                Turnover = 300,
                BetCount = 3
            };

            var expectedObject = new DetailModel
            {
                Date = DateTime.MinValue,
                GroupHeadline = "",
                Site = "",
                Currency = "",
                Super = "",
                Product = "",
                MemberRequest = "No",
                Status = "",
                Username = "",
                CustId = 0,
                WinLoss = 300,
                Turnover = 500,
                BetCount = 5
            };

            // Act
            var sumObject = firstObject + secondObject;

            // Assert
            Assert.That(sumObject, IsDeeplyEqual.To(expectedObject));
        }
    }
}
