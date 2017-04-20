using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UniversalReports.PlayForFun.Filter;
using UniversalReports.PlayForFun.Tests.DependencyInjection;
using ProductEntity = UniversalReports.PlayForFun.Filter.Product.ProductEntity;

namespace UniversalReports.PlayForFun.Tests.Filter
{
    public class PlayForFunFilterControllerTests
    {
        [Test]
        public async Task Product_FileRepository_ReturnsNonEmptyListOfProduct()
        {
            // Arrange
            const string FakeRepositoryDataFileName = "Filter-Product-FileRepository.json";
            var factory = new ApiControllerFactoryMethodFetchAsync();
            var controller = factory.CreateController<PlayForFunFilterController, ProductEntity>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Product();
            var viewModelJson = (httpActionResult as JsonResult<IEnumerable<ProductEntity>>).Content;

            // Assert
            Assert.That(viewModelJson, Has.Count.GreaterThan(0));

            // Release
            factory.Dispose();
        }
    }
}