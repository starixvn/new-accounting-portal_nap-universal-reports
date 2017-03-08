using AutoMapper;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetType;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.UnitTests.BetType
{
    public class HandlerUnitTests
    {
        [Test]
        public async Task Handle_ServiceReturnsEmptyModelBaseWithBetType_ReturnsEmptyViewModelJson()
        {
            // Arrange
            var emptyModelBaseWithBetType = CreateEmptyModelBaseWithTypeModel();
            var service = Substitute.For<PunterAnalysisService>();
            service.Query<BetTypeModel>(Arg.Any<ICriteria>()).Returns(emptyModelBaseWithBetType);

            var mapper = CreateMapper();

            // Act
            var handler = new Handler(mapper, service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ModelBase<BetTypeModel> CreateEmptyModelBaseWithTypeModel()
        {
            return new ModelBase<BetTypeModel>
            {
                Entities = new List<BetTypeModel>(),
                Total = new BetTypeModel()
            };
        }

        private ViewModelJson CreateEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                Entities = new List<BetTypeModel>(),
                Total = new BetTypeModel()
            };
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ModelBase<BetTypeModel>, ViewModelJson>();
                cfg.CreateMap<HttpParameterJson, Criteria>();
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }

        [Test]
        public async Task Handle_ServiceReturnsNonEmptyModelBaseWithBetType_ReturnsNonEmptyViewModelJson()
        {
            // Arrange
            var nonEmptyModelBaseWithBetTypeModel = CreateNonEmptyModelBaseWithBetTypeModel();
            var service = Substitute.For<PunterAnalysisService>();
            service.Query<BetTypeModel>(Arg.Any<ICriteria>()).Returns(nonEmptyModelBaseWithBetTypeModel);

            var mapper = CreateMapper();

            // Act
            var handler = new Handler(mapper, service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateNonEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ModelBase<BetTypeModel> CreateNonEmptyModelBaseWithBetTypeModel()
        {
            return new ModelBase<BetTypeModel>
            {
                Entities = new List<BetTypeModel> { CreateBetTypeModel() },
                Total = CreateBetTypeModel()
            };
        }

        private ViewModelJson CreateNonEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                Entities = new List<BetTypeModel> { CreateBetTypeModel() },
                Total = CreateBetTypeModel()
            };
        }

        private BetTypeModel CreateBetTypeModel()
        {
            return new BetTypeModel
            {
                BetType = "Bet Type 1",
                NonLiveWinLoss = 100,
                NonLiveTurnover = 200,
                NonLiveBetCount = 2,
                LiveWinLoss = 200,
                LiveTurnover = 300,
                LiveBetCount = 3,
                WinLoss = 300,
                Turnover = 500,
                BetCount = 5
            };
        }
    }
}
