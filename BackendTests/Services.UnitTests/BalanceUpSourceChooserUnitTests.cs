using NAP.Reports.CompanyWinLoss.Models;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests
{
    public class BalanceUpSourceChooserUnitTests
    {
        private static BalanceUpRange _balanceUpRange = new BalanceUpRange { BalanceUpDate = new DateTime(2015, 06, 01), MoveBetsDate = new DateTime(2015, 09, 01) };

        [Test]
        [Category("BalanceUpSourceChooserUnitTests")]
        public void Determine_StartDateAfterMoveBetsDate_ReturnsOneSource()
        {
            // Arrange
            var startDate = new DateTime(2015, 10, 01);
            var endDate = new DateTime(2015, 11, 01);
            var balanceUpService = Substitute.For<IBalanceUpService>();
            balanceUpService.Query().Returns(_balanceUpRange);
            var balancerUpSourceChooser = new BalanceUpSourceChooser(balanceUpService);

            // Act
            var result = balancerUpSourceChooser.Determine(startDate, endDate);

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        [Category("BalanceUpSourceChooserUnitTests")]
        public void Determine_StartDateBetweenBalanceUpRange_EndDateAfterMoveBetsDate_ReturnsTwoSources()
        {
            // Arrange
            var startDate = new DateTime(2015, 07, 01);
            var endDate = new DateTime(2015, 11, 01);

            var balanceUpService = Substitute.For<IBalanceUpService>();
            balanceUpService.Query().Returns(_balanceUpRange);
            var balancerUpSourceChooser = new BalanceUpSourceChooser(balanceUpService);

            // Act
            var result = balancerUpSourceChooser.Determine(startDate, endDate);

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        [Category("BalanceUpSourceChooserUnitTests")]
        public void Determine_StartDateBetweenBalanceUpRange_EndDateBeforeMoveBetsDate_ReturnsOneSource()
        {
            // Arrange
            var startDate = new DateTime(2015, 07, 01);
            var endDate = new DateTime(2015, 08, 01);

            var balanceUpService = Substitute.For<IBalanceUpService>();
            balanceUpService.Query().Returns(_balanceUpRange);
            var balancerUpSourceChooser = new BalanceUpSourceChooser(balanceUpService);

            // Act
            var result = balancerUpSourceChooser.Determine(startDate, endDate);

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        [Category("BalanceUpSourceChooserUnitTests")]
        public void Determine_StartDateBeforeBalanceUpDate_EndDateAfterMoveBetsDate_ReturnThreeSources()
        {
            // Arrange
            var startDate = new DateTime(2015, 03, 01);
            var endDate = new DateTime(2015, 11, 01);

            var balanceUpService = Substitute.For<IBalanceUpService>();
            balanceUpService.Query().Returns(_balanceUpRange);
            var balancerUpSourceChooser = new BalanceUpSourceChooser(balanceUpService);

            // Act
            var result = balancerUpSourceChooser.Determine(startDate, endDate);

            // Assert          
            Assert.AreEqual(3, result.Count());
        }

        [Test]
        [Category("BalanceUpSourceChooserUnitTests")]
        public void Determine_StartDateBeforeBalanceUpDate_EndDateBetweenBalanceUpDRange_ReturnTwoSources()
        {
            // Arrange
            var startDate = new DateTime(2015, 03, 01);
            var endDate = new DateTime(2015, 08, 01);

            var balanceUpService = Substitute.For<IBalanceUpService>();
            balanceUpService.Query().Returns(_balanceUpRange);
            var balancerUpSourceChooser = new BalanceUpSourceChooser(balanceUpService);

            // Act
            var result = balancerUpSourceChooser.Determine(startDate, endDate);

            // Assert          
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        [Category("BalanceUpSourceChooserUnitTests")]
        public void Determine_StartDateAndEndDateBeforeBalanceUpDate_ReturnOneSource()
        {
            // Arrange
            var startDate = new DateTime(2015, 03, 01);
            var endDate = new DateTime(2015, 04, 01);

            var balanceUpService = Substitute.For<IBalanceUpService>();
            balanceUpService.Query().Returns(_balanceUpRange);
            var balancerUpSourceChooser = new BalanceUpSourceChooser(balanceUpService);

            // Act
            var result = balancerUpSourceChooser.Determine(startDate, endDate);

            // Assert          
            Assert.AreEqual(1, result.Count());
        }
    }
}
