using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PunterAnalysis.SportType;
using UniversalReports.PunterAnalysis.SportType.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;

namespace UniversalReports.PunterAnalysis.Tests.SportType
{
    public class PunterAnalysisSportTypeControllerTests
    {
        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            ViewModelJson viewModelJson = null;
            const string FakeRepositoryDataFileName = "SportType-FileRepository.json";
            const string ExpectedViewModelJsonFileName = "SportType-ExpectedViewModelJson.json";

            var fakeSportTypeModelListFromRepository = TestDataLoader.Load<List<SportTypeModel>>(FakeRepositoryDataFileName);
            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<SportTypeModel>(Arg.Any<ICriteria>()).Returns(fakeSportTypeModelListFromRepository);

            // Act
            PunterAnalysisSportTypeController controller;
            using (var simpleInjectorTest = new SimpleInjectorTest(repository))
            {
                controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisSportTypeController)) as PunterAnalysisSportTypeController;
                var httpActionResult = await controller.Index(new HttpParameterJson());
                viewModelJson = (httpActionResult as JsonResult<ViewModelJson>).Content;
            }

            // Assert
            Assert.That(viewModelJson, IsDeeplyEqual.To(expectedViewModelJson));
        }
    }
}