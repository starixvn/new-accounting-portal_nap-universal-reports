using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.UnitTests.Core
{
    public class PunterAnalysisServiceImpUnitTests
    {
        [Test]
        public async void Query_RepositoryReturnsListWithOneItem_ReturnsRightModelBaseWithBetType()
        {
            // Arrange
            var betTypeModelListWithOneItem = CreateBetTypeModelListWithOneItem();
            var repository = Substitute.For<IDynamicRepository>();
            repository.Fetch<BetTypeModel>(Arg.Any<ICriteria>()).Returns(betTypeModelListWithOneItem);

            // Act
            var punterAnalysisService = new PunterAnalysisServiceImp(repository);
            var modelBase = await punterAnalysisService.Query<ModelBase<BetTypeModel>>(Arg.Any<ICriteria>());

            // Assert
            var expected = CreateModelBaseWithOneBetTypeModel();
            Assert.That(modelBase, IsDeeplyEqual.To(expected));
        }

        private List<BetTypeModel> CreateBetTypeModelListWithOneItem()
        {
            return new List<BetTypeModel>
            {
                CreateBetTypeModel()
            };
        }

        private BetTypeModel CreateBetTypeModel()
        {
            return new BetTypeModel
            {
                BetCount = 1,
                DrawCount = 1,
                WinCount = 1,
                WinLoss = 100,
                Date = DateTime.MinValue
            };
        }

        private ModelBase<BetTypeModel> CreateModelBaseWithOneBetTypeModel()
        {
            return new ModelBase<BetTypeModel>
            {
                Entities = CreateBetTypeModelListWithOneItem(),
                Total = CreateBetTypeModel()
            };
        }

        [Test]
        public async void Query_RepositoryReturnsEmptyList_ReturnsEmptyModelBaseWithBetType()
        {
            // Arrange
            var emptyBetTypeModelList = new List<BetTypeModel>();
            var repository = Substitute.For<IDynamicRepository>();
            repository.Fetch<BetTypeModel>(Arg.Any<ICriteria>()).Returns(emptyBetTypeModelList);

            // Act
            var punterAnalysisService = new PunterAnalysisServiceImp(repository);
            var modelBase = await punterAnalysisService.Query<ModelBase<BetTypeModel>>(Arg.Any<ICriteria>());

            // Assert
            var expected = CreateEmptyModelBaseWithTypeModel();
            Assert.That(modelBase, IsDeeplyEqual.To(expected));
        }

        private ModelBase<BetTypeModel> CreateEmptyModelBaseWithTypeModel()
        {
            return new ModelBase<BetTypeModel>
            {
                Entities = new List<BetTypeModel>(),
                Total = new BetTypeModel()
            };
        }
    }
}
