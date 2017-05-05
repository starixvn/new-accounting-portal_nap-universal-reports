using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Filter.ProductSportBetType;

namespace UniversalReports.PunterAnalysis.UnitTests.Filter.ProductSportBetType
{
    public class HandlerUnitTests
    {
        public static IEnumerable<IEnumerable<ProductSportBetTypeEntity>> ProductSportBetTypeTestCases
        {
            get
            {
                yield return new List<ProductSportBetTypeEntity>();
                yield return new List<ProductSportBetTypeEntity> { CreateProductSportBetTypeEntity() };
            }
        }

        [Test]
        [TestCaseSource(typeof(HandlerUnitTests), nameof(ProductSportBetTypeTestCases))]
        public async Task Handle_Always_ReturnsTheValueWhichIsReturnedByRepository(IEnumerable<ProductSportBetTypeEntity> valueFromRepository)
        {
            // Arrange
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<ProductSportBetTypeEntity>(Arg.Any<QueryCriteria>())
                .Returns(valueFromRepository);

            // Act
            var parameter = new HttpParameterJson();
            var handler = new Handler(repository);

            var result = await handler.Handle(parameter);
            Assert.That(result, IsDeeplyEqual.To(valueFromRepository));
        }

        private static ProductSportBetTypeEntity CreateProductSportBetTypeEntity()
        {
            return new ProductSportBetTypeEntity
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