using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using Olympus.FPSAPI.Client;
using Olympus.FPSAPI.Client.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.AssociatedAccount;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.AssociatedAccount
{
    using Configurations;

    public class AssociatedFacadeUnitTests
    {
        [Test]
        public async Task Query_FPSRetunsNonEmptyUsernameList_ReturnsSumDataOfDataFromRepository()
        {
            // Arrange
            var memberNonEmptySummary = new List<AssociatedSummaryModel>
            {
                new AssociatedSummaryModel
                {
                    Username = "member01",
                    RoleName = "Member",
                    BetCount = 1,
                    Turnover = 100,
                    WinLoss = 100,
                    Category = "category 1"
                },
                new AssociatedSummaryModel
                {
                    Username = "member02",
                    RoleName = "Member",
                    BetCount = 0,
                    Turnover = 0,
                    WinLoss = 0,
                    Category = "category 1"
                },
                new AssociatedSummaryModel
                {
                    Username = "agent01",
                    RoleName = "Agent",
                    Category = "category 1"
                }
            };

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<AssociatedSummaryModel>(Arg.Compat.Any<ICriteria>()).Returns(memberNonEmptySummary);

            var listOfUserDevice = new List<CustomerDevice> {
                 new CustomerDevice { Account = "member01" },
                 new CustomerDevice { Account = "member02" },
                 new CustomerDevice { Account = "agent01" },
            };
            var fraudService = Substitute.For<FraudServiceWrapper>();
            fraudService.GetAssociatedCustomers(Arg.Compat.Any<string>(), Arg.Compat.Any<int>()).Returns(listOfUserDevice);
            fraudService.GetCategory(Arg.Compat.Any<string>(), Arg.Compat.Any<string>()).Returns("category 1");

            var configurationService = Substitute.For<ConfigurationService>();

            // Act
            var facade = new AssociatedFacadeImp(repository, fraudService, configurationService);
            var viewModel = await facade.Query(new HttpParameterJson());

            // Assert
            var expectedEntities = new List<AssociatedSummaryModel>
            {
                new AssociatedSummaryModel { Username = "member01", BetCount = 1, RoleName = "Member", Turnover = 100, WinLoss = 100, Category = "category 1" },
                new AssociatedSummaryModel { Username = "member02", BetCount = 0, RoleName = "Member", Turnover = 0, WinLoss = 0, Category = "category 1" },
                new AssociatedSummaryModel { Username = "agent01", BetCount = 0, RoleName = "Agent", Turnover = 0, WinLoss = 0, Category = "category 1" }
            };

            var expected = new SummaryEntity<AssociatedSummaryModel>
            {
                Entities = expectedEntities,
                Total = new AssociatedSummaryModel { Username = string.Empty, BetCount = 1, RoleName = string.Empty, Turnover = 100, WinLoss = 100 }
            };
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }
    }
}