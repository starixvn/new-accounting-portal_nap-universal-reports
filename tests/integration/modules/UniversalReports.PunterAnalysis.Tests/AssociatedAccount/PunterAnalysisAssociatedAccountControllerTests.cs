using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PunterAnalysis.AssociatedAccount;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;

namespace UniversalReports.PunterAnalysis.Tests.AssociatedAccount
{
    public class PunterAnalysisAssociatedAccountControllerTests
    {
        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            const string FakeRepositoryDataFileName = "AssociatedAccount-FileRepository.json";
            const string ExpectedViewModelJsonFileName = "AssociatedAccount-ExpectedViewModelJson.json";

            var fakeUserRoleListFromRepository = TestDataLoader.Load<List<UserRoleModel>>(FakeRepositoryDataFileName);
            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<UserRoleModel>(Arg.Any<UserRoleQueryCriteria>()).Returns(fakeUserRoleListFromRepository);
            repository.GetAsync<string>(Arg.Any<UserSiteQueryCriteria>()).Returns((object)Task.FromResult("12bet"));

            // Act
            var factory = new ApiControllerFactoryMethodAbsoluteRepository();
            var controller = factory.CreateController<PunterAnalysisAssociatedAccountController>(repository);
            var httpActionResult = await controller.Index(new HttpParameterJson { Username = "sa", CustId = 8 });
            var viewModelJson = (httpActionResult as JsonResult<ViewModelJson>).Content;

            // Assert
            Assert.That(viewModelJson, IsDeeplyEqual.To(expectedViewModelJson));

            // Release
            factory.Dispose();
        }
    }
}