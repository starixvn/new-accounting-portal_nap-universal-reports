using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PlayForFun.Filter.Product;

namespace UniversalReports.PlayForFun.UnitTests.Filter.Product
{
    public class HandlerUnitTests
    {
        public static IEnumerable<IEnumerable<ProductEntity>> ProductTestCases
        {
            get
            {
                yield return new List<ProductEntity>();
                yield return new List<ProductEntity> { CreateProductEntity() };
            }
        }

        [Test]
        [TestCaseSource(typeof(HandlerUnitTests), nameof(ProductTestCases))]
        public async Task Handle_Always_ReturnsTheValueWhichIsReturnedByRepository(IEnumerable<ProductEntity> valueFromRepository)
        {
            // Arrange
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<ProductEntity>(Arg.Any<QueryCriteria>())
                .Returns(valueFromRepository);

            // Act
            var parameter = new HttpParameterJson();
            var handler = new Handler(repository);

            var result = await handler.Handle(parameter);
            Assert.That(result, IsDeeplyEqual.To(valueFromRepository));
        }

        private static ProductEntity CreateProductEntity()
        {
            return new ProductEntity
            {
                BetTypeName = "Any Bet Type Name",
                ProductName = "Any Product Name",
                RenderType = 1,
                SportGroup = "Any Sport Group",
                SportName = "Any Sport Name",
                Value = 1
            };
        }
    }
}
