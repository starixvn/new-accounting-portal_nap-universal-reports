using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using Olympus.FPSAPI.Client;
using Olympus.FPSAPI.Client.Model;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.AssociatedAccount;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.AssociatedAccount
{
    public class AssociatedFacadeUnitTests
    {
        [Test]
        public async Task Query_FPSRetunsNonEmptyUsernameList_ReturnsSumDataOfDataFromRepository()
        {
            // Arrange
            var site = new Site { Name = "site01", IsCreditSite = false };
            var memberNonEmptySummary = new List<AssociatedSummaryModel>
            {
                new AssociatedSummaryModel
                {
                    Username = "member01",
                    RoleName = "Member",
                    BetCount = 1,
                    Turnover = 100,
                    WinLoss = 100
                },
                new AssociatedSummaryModel
                {
                    Username = "member02",
                    RoleName = "Member",
                    BetCount = 0,
                    Turnover = 0,
                    WinLoss = 0
                },
                new AssociatedSummaryModel
                {
                    Username = "agent01",
                    RoleName = "Agent"
                }
            };

            var repository = Substitute.For<IDynamicRepository>();
            repository.GetAsync<Site>(Arg.Any<UserSiteQueryCriteria>()).Returns(site);
            repository.FetchAsync<AssociatedSummaryModel>(Arg.Any<ICriteria>()).Returns(memberNonEmptySummary);

            var listOfUserDevice = new List<CustomerDevice> {
                 new CustomerDevice { Account = "member01" },
                 new CustomerDevice { Account = "member02" },
                 new CustomerDevice { Account = "agent01" },
            };
            var fraudService = Substitute.For<FraudServiceWrapper>();
            fraudService.GetAssociatedCustomers(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>()).Returns(listOfUserDevice);

            var configurationService = Substitute.For<ConfigurationService>();

            // Act
            var facade = new AssociatedFacadeImp(configurationService, fraudService, repository);
            var viewModel = await facade.Query(new HttpParameterJson()).ConfigureAwait(false);

            // Assert
            var expectedEntities = new List<AssociatedSummaryModel>
            {
                new AssociatedSummaryModel { Username = "member01", BetCount = 1, RoleName = "Member", Turnover = 100, WinLoss = 100 },
                new AssociatedSummaryModel { Username = "member02", BetCount = 0, RoleName = "Member", Turnover = 0, WinLoss = 0 },
                new AssociatedSummaryModel { Username = "agent01", BetCount = 0, RoleName = "Agent", Turnover = 0, WinLoss = 0 }
            };

            var expected = new SummaryEntity<AssociatedSummaryModel>
            {
                Entities = expectedEntities,
                Total = new AssociatedSummaryModel { Username = string.Empty, BetCount = 1, RoleName = string.Empty, Turnover = 100, WinLoss = 100 }
            };
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        [Test]
        public async Task Query_FPSRetunsEmptyUsernameList_ReturnsEmptySummaryEntity()
        {
            // Arrange
            var site = new Site { Name = "site01", IsCreditSite = false };

            var repository = Substitute.For<IDynamicRepository>();
            repository.GetAsync<Site>(Arg.Any<UserSiteQueryCriteria>()).Returns(site);

            var emptyListOfUserDevice = new List<CustomerDevice>();
            var fraudService = Substitute.For<FraudServiceWrapper>();
            fraudService.GetAssociatedCustomers(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>()).Returns(emptyListOfUserDevice);

            var configurationService = Substitute.For<ConfigurationService>();

            // Act
            var facade = new AssociatedFacadeImp(configurationService, fraudService, repository);
            var viewModel = await facade.Query(new HttpParameterJson()).ConfigureAwait(false);

            // Assert
            var expectedEntities = new List<AssociatedSummaryModel>();

            var expected = new SummaryEntity<AssociatedSummaryModel>
            {
                Entities = expectedEntities,
                Total = new AssociatedSummaryModel()
            };
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }
    }
}