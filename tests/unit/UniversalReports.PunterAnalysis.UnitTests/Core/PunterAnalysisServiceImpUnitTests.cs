using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.UnitTests.Core
{
    public class PunterAnalysisServiceImpUnitTests
    {
        [Test]
        public async Task Query_RepositoryReturnsEmptyBetTypeModelList_ReturnsEmptyModelBaseWithBetTypeModel()
        {
            // Arrange
            var emptyBetTypeModelList = new List<BetTypeModel>();
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<BetTypeModel>(Arg.Any<ICriteria>()).Returns(emptyBetTypeModelList);

            // Act
            var punterAnalysisService = new PunterAnalysisServiceImp(repository);
            var modelBase = await punterAnalysisService.Query<BetTypeModel>(Arg.Any<ICriteria>());

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

        [Test]
        public async Task Query_RepositoryReturnsNonEmptyBetTypeModelList_ReturnsNonEmptyModelBaseWithBetTypeModel()
        {
            // Arrange
            var nonEmptyBetTypeModelList = CreateNonEmptyBetTypeModelList();
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<BetTypeModel>(Arg.Any<ICriteria>()).Returns(nonEmptyBetTypeModelList);

            // Act
            var punterAnalysisService = new PunterAnalysisServiceImp(repository);
            var modelBase = await punterAnalysisService.Query<BetTypeModel>(Arg.Any<ICriteria>());

            // Assert
            var expected = CreateNonEmptyModelBaseWithBetTypeModel();
            Assert.That(modelBase, IsDeeplyEqual.To(expected));
        }

        private List<BetTypeModel> CreateNonEmptyBetTypeModelList()
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

        private ModelBase<BetTypeModel> CreateNonEmptyModelBaseWithBetTypeModel()
        {
            return new ModelBase<BetTypeModel>
            {
                Entities = CreateNonEmptyBetTypeModelList(),
                Total = CreateBetTypeModel()
            };
        }
    }
}
