using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.AssociatedAccount;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.AssociatedAccount
{
    public class HandlerUnitTests
    {
        [Test]
        public async Task Handle_RepositoryAndFraudServiceReturnEmptyData_ReturnsEmptyViewModelJson()
        {
            // Arrange
            var emptyListOfUserRoleModel = new List<UserRoleModel>();
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<UserRoleModel>(Arg.Any<UserRoleQueryCriteria>()).Returns(emptyListOfUserRoleModel);
            repository.GetAsync<string>(Arg.Any<UserSiteQueryCriteria>()).Returns((object)Task.FromResult(string.Empty));

            var fraudService = Substitute.For<FraudServiceWrapper>();
            var emptyListOfUserDevice = new List<UserDevice>();
            fraudService.GetAssociatedUsers(Arg.Any<string>(), Arg.Any<string>()).Returns(emptyListOfUserDevice);

            // Act
            var handler = new Handler(repository, fraudService);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = new ViewModelJson(emptyListOfUserRoleModel);
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        [Test]
        public async Task Handle_RepositoryAndFraudServiceReturnNonEmptyData_ReturnsNonEmptyViewModelJson()
        {
            // Arrange
            var nonEmptyListOfUserRoleModel = new List<UserRoleModel>
            {
                 new UserRoleModel
                 {
                     Username = "User 1",
                     RoleName = "Master"
                 }
            };
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<UserRoleModel>(Arg.Any<ICriteria>()).Returns(nonEmptyListOfUserRoleModel);
            repository.GetAsync<string>(Arg.Any<UserSiteQueryCriteria>()).Returns((object)Task.FromResult("Site 1"));

            var nonEmptyListOfUserDevice = new List<UserDevice>()
            {
                new UserDevice { Account = "User 1" }
            };
            var fraudService = Substitute.For<FraudServiceWrapper>();
            fraudService.GetAssociatedUsers(Arg.Any<string>(), Arg.Any<string>()).Returns(nonEmptyListOfUserDevice);

            // Act
            var handler = new Handler(repository, fraudService);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = new ViewModelJson(nonEmptyListOfUserRoleModel);
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }
    }
}
