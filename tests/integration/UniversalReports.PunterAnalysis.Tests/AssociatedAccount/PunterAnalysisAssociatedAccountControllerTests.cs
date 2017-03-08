using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;
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
            const string fakeRepositoryDataFileName = "AssociatedAccount-FileRepository.json";
            const string expectedViewModelJsonFileName = "AssociatedAccount-ExpectedViewModelJson.json";
            var fakeAssociatedAccountModelListFromRepository = TestDataLoader.Load<List<AssociatedAccountModel>>(fakeRepositoryDataFileName);
            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(expectedViewModelJsonFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<AssociatedAccountModel>(Arg.Any<ICriteria>()).Returns(fakeAssociatedAccountModelListFromRepository);

            var simpleInjectorTest = new SimpleInjectorTest(repository);

            // Act
            var controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisAssociatedAccountController)) as PunterAnalysisAssociatedAccountController;
            var httpActionResult = await controller.Index(new HttpParameterJson());
            var viewModelJson = (httpActionResult as JsonResult<ViewModelJson>).Content;

            // Assert
            Assert.That(viewModelJson, IsDeeplyEqual.To(expectedViewModelJson));
        }
    }
}
