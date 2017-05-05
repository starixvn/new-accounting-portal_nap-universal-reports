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
        public async Task Handle_Always_ReturnsListOfUserRoleFromRepository()
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

            var nonEmptyListOfUserDevice = new List<UserDevice>
            {
                new UserDevice { Account = "User 1" }
            };
            var fraudService = Substitute.For<FraudServiceWrapper>();
            fraudService.GetAssociatedUsers(Arg.Any<string>(), Arg.Any<string>()).Returns(nonEmptyListOfUserDevice);

            // Act
            var handler = new Handler(repository, fraudService);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = new List<UserRoleModel>(nonEmptyListOfUserRoleModel);
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }
    }
}