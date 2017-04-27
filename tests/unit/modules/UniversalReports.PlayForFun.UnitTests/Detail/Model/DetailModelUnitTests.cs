using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using UniversalReports.PlayForFun.Detail.Model;

namespace UniversalReports.PlayForFun.UnitTests.Detail.Model
{
    public class DetailModelUnitTests
    {
        [Test]
        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules",
            "SP2101:MethodMustNotContainMoreLinesThan",
            Justification = "Reviewed. Suppression is OK here.")]
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
                MemberRequest = 0,
                Status = 1,
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
                MemberRequest = 0,
                Status = 0,
                Username = "User 2",
                CustId = 2,
                WinLoss = 200,
                Turnover = 300,
                BetCount = 3
            };

            var expectedObject = new DetailModel
            {
                Date = DateTime.MinValue,
                GroupHeadline = string.Empty,
                Site = string.Empty,
                Currency = string.Empty,
                Super = string.Empty,
                Product = string.Empty,
                MemberRequest = 0,
                Status = 0,
                Username = string.Empty,
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

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void GroupHeadline_Empty_ShouldReturnNA(string groupHeadline)
        {
            var model = new DetailModel
            {
                GroupHeadline = groupHeadline
            };

            Assert.That(model.GroupHeadline, Is.EqualTo("N/A"));
        }

        [Test]
        [TestCase("Any non empty string", ExpectedResult = "Any non empty string")]
        [TestCase("N/A", ExpectedResult = "N/A")]
        public string GroupHeadline_NonEmpty_ShouldReturnString(string groupHeadline)
        {
            var model = new DetailModel
            {
                GroupHeadline = groupHeadline
            };

            return model.GroupHeadline;
        }
    }
}
