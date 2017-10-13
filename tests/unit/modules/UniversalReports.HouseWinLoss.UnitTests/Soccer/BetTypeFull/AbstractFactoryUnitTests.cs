using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Soccer.BetTypeFull;
using UniversalReports.HouseWinLoss.Soccer.GroupBetType;
using UniversalReports.HouseWinLoss.Soccer.SumBetType;

namespace UniversalReports.HouseWinLoss.UnitTests.Soccer.BetTypeFull
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class AbstractFactoryUnitTests
    {
        [Test]
        public void CreateGridOptionFactory_MajorAndLiveNonLive_ReturnsGridOptionFactorySumBetType()
        {
            // Arrange
            var abstractFactory = CreateAbstractFactory();

            // Act
            var gridOptionFactory = abstractFactory.CreateGridOptionFactory(true, 2);

            // Assert
            Assert.That(gridOptionFactory, Is.AssignableTo<GridOptionFactorySumBetType>());
        }

        [Test]
        public void CreateGridOptionFactory_MajorAndNonLive_ReturnsGridOptionFactoryGroupBetType()
        {
            // Arrange
            var abstractFactory = CreateAbstractFactory();

            // Act
            var gridOptionFactory = abstractFactory.CreateGridOptionFactory(true, 0);

            // Assert
            Assert.That(gridOptionFactory, Is.AssignableTo<GridOptionFactoryGroupBetType>());
        }

        [Test]
        [TestCase(true, 1)]
        [TestCase(false, 2)]
        [TestCase(false, 1)]
        [TestCase(false, 0)]
        public void CreateGridOptionFactory_NormalCases_ReturnsGridOptionFactoryBetType(bool isMajor, int isLive)
        {
            // Arrange
            var abstractFactory = CreateAbstractFactory();

            // Act
            var gridOptionFactory = abstractFactory.CreateGridOptionFactory(isMajor, isLive);

            // Assert
            Assert.That(gridOptionFactory, Is.AssignableTo<GridOptionFactoryBetType>());
        }

        private AbstractFactory CreateAbstractFactory()
        {
            var sumBetTypeWinLossService = Substitute.For<SumBetTypeWinLossService>();
            var sumBetTypeGridOptionsBuilder = Substitute.For<SumBetTypeGridOptionsBuilder>();
            var groupBetTypeWinLossService = Substitute.For<GroupBetTypeWinLossService>();
            var groupBetTypeGridOptionsBuilder = Substitute.For<GroupBetTypeGridOptionsBuilder>();
            var basicWinLossService = Substitute.For<BasicWinLossService>();
            var basicGridOptionsBuilder = Substitute.For<BasicGridOptionsBuilder>();

            var columnRemoval = Substitute.For<GridOptionColumnRemoval>();
            var decorator = Substitute.For<GridOptionColumnDecoratorVirtual>(columnRemoval);

            return new AbstractFactoryImp(
                sumBetTypeWinLossService,
                sumBetTypeGridOptionsBuilder,
                groupBetTypeWinLossService,
                groupBetTypeGridOptionsBuilder,
                basicWinLossService,
                basicGridOptionsBuilder,
                decorator);
        }
    }
}
