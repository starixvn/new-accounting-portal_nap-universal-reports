using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PunterAnalysis.BetCount;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Tests.DependencyInjection;

namespace UniversalReports.PunterAnalysis.Tests.BetCount
{
    public class PunterAnalysisBetCountControllerTests
    {
        [Test]
        public async Task Index_FileRepository_ReturnsRightViewModelJson()
        {
            // Arrange
            const string FakeRepositoryDataFileName = "BetCount-FileRepository.json";
            const string ExpectedViewModelJsonFileName = "BetCount-ExpectedViewModelJson.json";

            var fakeBetCountModelListFromRepository = TestDataLoader.Load<List<BetCountModel>>(FakeRepositoryDataFileName);
            var expectedViewModelJson = TestDataLoader.Load<ViewModelJson>(ExpectedViewModelJsonFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<BetCountModel>(Arg.Any<ICriteria>()).Returns(fakeBetCountModelListFromRepository);

            PunterAnalysisBetCountController controller;
            using (var simpleInjectorTest = new SimpleInjectorTest(repository))
            {
                controller = simpleInjectorTest.GetInstance(typeof(PunterAnalysisBetCountController)) as PunterAnalysisBetCountController;
            }

            var httpActionResult = await controller.Index(new HttpParameterJson());
            var viewModelJson = (httpActionResult as JsonResult<ViewModelJson>).Content;

            // Assert
            Assert.That(viewModelJson, IsDeeplyEqual.To(expectedViewModelJson));
        }
    }
}