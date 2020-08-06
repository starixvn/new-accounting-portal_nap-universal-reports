using AutoFixture;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.SMAWinLoss.VirtualRate;

namespace UniversalReports.SMAWinLoss.UnitTests.VirtualRate
{
    [TestFixture]
    [Category("SMAWinLoss")]
    public class VirtualRateServiceTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task GetVirtualRate_WithSubtituteReposity_ReturnRightVirtualRate()
        {
            // Arrange
            var rates = fixture.Create<IEnumerable<VirtualRateModel>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<VirtualRateModel>(Arg.Compat.Any<VirtualRateCriteria>()).Returns(rates);

            var service = new VirtualRateServiceImp(repository);

            // Act
            var model = await service.GetVirtualRate(new VirtualRateHttpParameter());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(rates));
        }
    }
}