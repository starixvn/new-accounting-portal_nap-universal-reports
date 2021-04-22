using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.CashOutPerformance.Criteria;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.Services;
using UniversalReports.CashOutPerformance.ViewModels;

namespace UniversalReports.CashOutPerformance.UnitTests.Services
{
    [TestFixture]
    [Category("CashOutPerformance")]
    public class CashOutPerformanceServiceTests
    {
        [Test]
        public async Task GetLicensees_ValidLicenseeCriteria_ReturnRightLicensees()
        {
            // Arrange
            var expectedLicensees = new List<FilterItemModel>
            {
                new FilterItemModel { Id = 871, Name = "108betTest" },
                new FilterItemModel { Id = 865, Name = "109betTest" }
            };

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<FilterItemModel>(Arg.Compat.Any<LicenseeCriteria>()).Returns(expectedLicensees);
            var service = new CashOutPerformanceServiceImp(repository);

            // Act
            var actualLicensees = await service.GetLicensees(new LicenseeCriteria());

            // Assert
            Assert.AreEqual(expectedLicensees, actualLicensees);
        }

        [Test]
        public async Task GetSports_ValidSportCriteria_ReturnRightSports()
        {
            // Arrange
            var expectedSports = new List<FilterItemModel>
            {
                new FilterItemModel { Id = 1, Name = "SOCCER" }
            };

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<FilterItemModel>(Arg.Compat.Any<SportCriteria>()).Returns(expectedSports);
            var service = new CashOutPerformanceServiceImp(repository);

            // Act
            var actualSports = await service.GetSports(new SportCriteria());

            // Assert
            Assert.AreEqual(expectedSports, actualSports);
        }

        [Test]
        public async Task GetTickets_ValidTicketCriteria_ReturnRightTickets()
        {
            // Arrange
            var expectedTicket = ValueTuple.Create<IEnumerable<TicketModel>, IEnumerable<TicketModel>, IEnumerable<int>>(
                new List<TicketModel>(),
                new List<TicketModel>(),
                new List<int>());

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchMultipleAsync<TicketModel, TicketModel, int>(Arg.Compat.Any<TicketCriteria>()).Returns(expectedTicket);
            var service = new CashOutPerformanceServiceImp(repository);

            // Act
            var actualTicket = await service.GetTickets(new TicketCriteria());

            // Assert
            Assert.AreEqual(expectedTicket.Item1, actualTicket.TicketList);
        }
    }
}
