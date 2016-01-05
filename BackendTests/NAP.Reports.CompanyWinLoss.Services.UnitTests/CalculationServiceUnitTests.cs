using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services.Models;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests
{
    public class CalculationServiceUnitTests
    {
        [Test]
        public void CalculateMargin_TurnoverIsZero_ReturnsZero()
        {
            // Arrange
            var zero = 0;
            var anyIncome = 12312;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.CalculateMargin(zero, anyIncome);

            // Assert
            Assert.AreEqual(zero, result);
        }

        [Test]
        public void CalculateMargin_TurnoverIsNotZero_ReturnsTheDividend()
        {
            // Arrange
            var expectedDevidend = 0.1m;
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.CalculateMargin(10m, 1m);

            // Assert
            Assert.AreEqual(expectedDevidend, result);
        }

        [Test]
        public void FromRawWinLoss_ReturnsCorrectVarianceAndMargin()
        {
            // Arrange
            var rawWinLoss = CreateRawWinLoss("Sportsbook Live", 100, 200, 10, 300, 400, 1000, 1200);
            var expectedWinLoss = CreateWinLoss("Sportsbook Live", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000m, 400m / 1200m);
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.FromRawWinLoss(rawWinLoss);

            // Assert
            var equal = AreTwoWinLossEqual(expectedWinLoss, result);
            Assert.True(equal);
        }

        [Test]
        public void CalculateTotal_ReturnsRightTotalValue()
        {
            // Arrange
            var expectedTotal = CreateWinLoss("Sportsbook Total", 460, 860, 100, 1260, 1660, -400, 4600, 5400, 1260.0m / 4600, 1660.0m / 5400);
            var rawWinLosses = CreateRawWinLosses();
            var calculationService = new CalculationService();

            // Act
            var result = calculationService.CalculateTotal(rawWinLosses, "Sportsbook Total");

            // Assert
            var areEqual = AreTwoWinLossEqual(expectedTotal, result);
            Assert.True(areEqual);
        }

        private RawWinLoss[] CreateRawWinLosses()
        {
            var liveWinLoss = CreateRawWinLoss("Sportsbook Live", 100, 200, 10, 300, 400, 1000, 1200);
            var nonLiveWinLoss = CreateRawWinLoss("Sportsbook Non-Live", 110, 210, 20, 310, 410, 1100, 1300);
            var parlayWinLoss = CreateRawWinLoss("Parlay", 120, 220, 30, 320, 420, 1200, 1400);
            var outrightWinLoss = CreateRawWinLoss("Outright", 130, 230, 40, 330, 430, 1300, 1500);

            return new RawWinLoss[] { liveWinLoss, nonLiveWinLoss, parlayWinLoss, outrightWinLoss };
        }

        private RawWinLoss CreateRawWinLoss(
            string title,
            decimal memberWinLoss,
            decimal smaWinLoss,
            decimal commission,
            decimal realIncome,
            decimal virtualIncome,
            decimal realTurnover,
            decimal virtualTurnover)
        {
            return new RawWinLoss
            {
                Title = title,
                MemberWinLoss = memberWinLoss,
                SMAWinLoss = smaWinLoss,
                Commission = commission,
                RealIncome = realIncome,
                VirtualIncome = virtualIncome,
                RealTurnover = realTurnover,
                VirtualTurnover = virtualTurnover
            };
        }


        private ProductWinLoss CreateExpectedProductWinLoss()
        {
            var liveWinLoss = CreateWinLoss("Sportsbook Live", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000, 400m / 1200);
            var nonLiveWinLoss = CreateWinLoss("Sportsbook Non-Live", 110, 210, 20, 310, 410, -100, 1100, 1300, 310.0m / 1100, 410.0m / 1300);
            var parlayWinLoss = CreateWinLoss("Parlay", 120, 220, 30, 320, 420, -100, 1200, 1400, 320.0m / 1200, 420.0m / 1400);
            var outrightWinLoss = CreateWinLoss("Outright", 130, 230, 40, 330, 430, -100, 1300, 1500, 330.0m / 1300, 430.0m / 1500);
            var totalWinLoss = CreateWinLoss("Sportsbook Total", 460, 860, 100, 1260, 1660, -400, 4600, 5400, 1260.0m / 4600, 1660.0m / 5400);

            return new ProductWinLoss
            {
                Products = new List<WinLoss> { liveWinLoss, nonLiveWinLoss, parlayWinLoss, outrightWinLoss },
                Total = totalWinLoss
            };

        }

        private WinLoss CreateWinLoss(
            string title,
            decimal memberWinLoss,
            decimal smaWinLoss,
            decimal commission,
            decimal realIncome,
            decimal virtualIncome,
            decimal varianceIncome,
            decimal realTurnover,
            decimal virtualTurnover,
            decimal realMargin,
            decimal virtualMargin)
        {
            return new WinLoss
            {
                Title = title,
                MemberWinLoss = memberWinLoss,
                SMAWinLoss = smaWinLoss,
                Commission = commission,
                RealIncome = realIncome,
                VirtualIncome = virtualIncome,
                RealTurnover = realTurnover,
                VirtualTurnover = virtualTurnover,
                VarianceIncome = varianceIncome,
                RealMargin = realMargin,
                VirtualMargin = virtualMargin
            };
        }

        //private bool AreTwoProductWinLossEqual(ProductWinLoss first, ProductWinLoss second)
        //{
        //    if (!AreTwoWinLossEqual(first.Total, second.Total))
        //    {
        //        return false;
        //    }

        //    var firstProductCount = first.Products.Count;
        //    var secondProductCount = second.Products.Count;

        //    if (firstProductCount != secondProductCount)
        //    {
        //        return false;
        //    }

        //    for (var i = 0; i < firstProductCount; i++)
        //    {
        //        if (!AreTwoWinLossEqual(first.Products[i], second.Products[i]))
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        private bool AreTwoWinLossEqual(WinLoss first, WinLoss second)
        {
            return first.Title == second.Title &&
                    first.MemberWinLoss == second.MemberWinLoss &&
                    first.SMAWinLoss == second.SMAWinLoss &&
                    first.Commission == second.Commission &&
                    first.RealIncome == second.RealIncome &&
                    first.VirtualIncome == second.VirtualIncome &&
                    first.RealTurnover == second.RealTurnover &&
                    first.VirtualTurnover == second.VirtualTurnover &&
                    first.VarianceIncome == second.VarianceIncome &&
                    first.RealMargin == second.RealMargin &&
                    first.VirtualMargin == second.VirtualMargin;
        }
    }
}
