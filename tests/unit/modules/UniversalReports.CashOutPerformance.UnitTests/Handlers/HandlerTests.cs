using Linq.DynamicSum;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.CashOutPerformance.Criteria;
using UniversalReports.CashOutPerformance.Handlers;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.Requests;
using UniversalReports.CashOutPerformance.Services;

namespace UniversalReports.CashOutPerformance.UnitTests.Handlers
{
    [TestFixture]
    [Category("CashOutPerformance")]
    public class HandlerTests
    {
        [Test]
        public async Task Handler_WithLicenseeRequest_ReturnRightLicensees()
        {
            // Arrange
            var expectedLicensees = new List<FilterItemModel>
            {
                new FilterItemModel { Id = 871, Name = "108betTest" },
                new FilterItemModel { Id = 865, Name = "109betTest" }
            };

            var cashOutPerformanceService = Substitute.For<CashOutPerformanceService>();
            cashOutPerformanceService.GetLicensees(Arg.Compat.Any<LicenseeCriteria>()).Returns(expectedLicensees);
            var handler = new Handler(cashOutPerformanceService);

            // Act
            var actualLicensees = await handler.Handle(new LicenseeRequest(), new CancellationToken());

            // Assert
            Assert.AreEqual(expectedLicensees, actualLicensees);
        }

        [Test]
        public async Task Handler_WithSportRequest_ReturnRightSports()
        {
            // Arrange
            var expectedSports = new List<FilterItemModel>
            {
                new FilterItemModel { Id = 1, Name = "SOCCER" }
            };

            var cashOutPerformanceService = Substitute.For<CashOutPerformanceService>();
            cashOutPerformanceService.GetSports(Arg.Compat.Any<SportCriteria>()).Returns(expectedSports);
            var handler = new Handler(cashOutPerformanceService);

            // Act
            var actualSports = await handler.Handle(new SportRequest(), new CancellationToken());

            // Assert
            Assert.AreEqual(expectedSports, actualSports);
        }

        [Test]
        public async Task Handler_WithTicketRequest_ReturnRightTickets()
        {
            // Arrange
            var expectedTicket = new List<TicketModel>
            {
                new TicketModel { }
            };

            var cashOutPerformanceService = Substitute.For<CashOutPerformanceService>();
            cashOutPerformanceService.GetTickets(Arg.Compat.Any<TicketCriteria>()).Returns(expectedTicket.CalculateSummaryEntity());
            var handler = new Handler(cashOutPerformanceService);

            // Act
            var actualTickets = await handler.Handle(new TicketRequest(), new CancellationToken());

            // Assert
            Assert.AreEqual(actualTickets.Entities, expectedTicket);
        }
    }
}
