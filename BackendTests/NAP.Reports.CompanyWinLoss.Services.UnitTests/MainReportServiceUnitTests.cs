using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services.Models;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests
{
    public class MainReportServiceUnitTests
    {
        [Test]
        public void Query_SportsbookAndTwoProducts_CallProductWinLossServiceToCalculateThreeTimes()
        {
            // Arrange            
            var productWinLossService = Substitute.For<IMainReportProductWinLossService>();
            var service = new MainReportService(productWinLossService, "Number Game", "Live Casino");

            // Act 
            var result = service.Query(Arg.Any<MainReportQuery>());

            // Assert
            productWinLossService.Query(Arg.Any<MainReportQuery>()).Received(3);
        }

        [Test]
        public void Query_SportsbookAndNumberGame_CalculateRightGrandTotal()
        {
            // Arrange
            var fakeSportsbookWinLoss = CreateFakeSportsbookWinLoss();
            var fakeNumberGameWinLoss = CreateFakeNumberGameWinLoss();
            var expectedTotal = CreateWinLoss("Grand Total", 800, 1500, 170, 2200, 2900, -700, 8000, 9400, 2200m / 8000, 2900m / 9400);
            var productWinLossService = Substitute.For<IMainReportProductWinLossService>();

            productWinLossService.Query("Sportsbook", Arg.Any<MainReportQuery>()).Returns(fakeSportsbookWinLoss);
            productWinLossService.Query("Number Game", Arg.Any<MainReportQuery>()).Returns(fakeSportsbookWinLoss);

            var service = new MainReportService(productWinLossService, "Number Game");

            // Act
            var result = service.Query(Arg.Any<MainReportQuery>());

            // Assert
            var equal = AreTwoWinLossEqual(expectedTotal, result.Total.Total);
            Assert.True(equal);
        }

        private ProductWinLoss CreateFakeSportsbookWinLoss()
        {
            var liveWinLoss = CreateWinLoss("Sportsbook Live", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000, 400m / 1200);
            var nonLiveWinLoss = CreateWinLoss("Sportsbook Non-Live", 110, 210, 20, 310, 410, -100, 1100, 1300, 310m / 1100, 410m / 1300);
            var parlayWinLoss = CreateWinLoss("Parlay", 120, 220, 30, 320, 420, -100, 1200, 1400, 320m / 1200, 420m / 1400);
            var outrightWinLoss = CreateWinLoss("Outright", 130, 230, 40, 330, 430, -100, 1300, 1500, 330m / 1300, 430m / 1500);
            var totalWinLoss = CreateWinLoss("Sportsbook Total", 590, 1090, 140, 1590, 2090, -500, 5900, 6900, 1590m / 5900, 2090m / 6900);

            return new ProductWinLoss
            {
                Products = new List<WinLoss> { liveWinLoss, nonLiveWinLoss, parlayWinLoss, outrightWinLoss },
                Total = totalWinLoss
            };
        }

        private ProductWinLoss CreateFakeNumberGameWinLoss()
        {
            var creditWinLoss = CreateWinLoss("Credit", 100, 200, 10, 300, 400, -100, 1000, 1200, 300m / 1000m, 400m / 1200m);
            var depositWinLoss = CreateWinLoss("Deposit", 110, 210, 20, 310, 410, -100, 1100, 1300, 310m / 1100m, 410m / 1300m);
            var totalWinLoss = CreateWinLoss("Number Game", 210, 410, 30, 610, 810, -200, 2100, 2500, 610m / 2100, 810m / 2500);
            return new ProductWinLoss
            {
                Products = new List<WinLoss> { creditWinLoss, depositWinLoss },
                Total = totalWinLoss
            };
        }

        #region ToDO

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

        private ProductWinLoss CreateExpectedMainReportWinLoss()
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

        private bool AreTwoProductWinLossEqual(ProductWinLoss first, ProductWinLoss second)
        {
            if (!AreTwoWinLossEqual(first.Total, second.Total))
            {
                return false;
            }

            var firstProductCount = first.Products.Count;
            var secondProductCount = second.Products.Count;

            if (firstProductCount != secondProductCount)
            {
                return false;
            }

            for (var i = 0; i < firstProductCount; i++)
            {
                if (!AreTwoWinLossEqual(first.Products[i], second.Products[i]))
                {
                    return false;
                }
            }

            return true;
        }

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

        #endregion
    }
}
