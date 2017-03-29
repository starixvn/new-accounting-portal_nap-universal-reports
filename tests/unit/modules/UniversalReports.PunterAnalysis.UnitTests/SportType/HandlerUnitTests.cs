using AutoMapper;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.SportType;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.SportType
{
    public class HandlerUnitTests
    {
        [Test]
        public async Task Handle_ServiceReturnsEmptyModelBaseWithSportType_ReturnsEmptyViewModelJson()
        {
            // Arrange
            var emptyModelBaseWithSportType = CreateEmptyModelBaseWithTypeModel();
            var service = Substitute.For<PunterAnalysisService>();
            service.Query<SportTypeModel>(Arg.Any<ICriteria>()).Returns(emptyModelBaseWithSportType);

            var mapper = CreateMapper();

            // Act
            var handler = new Handler(mapper, service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ReportModelBase<SportTypeModel> CreateEmptyModelBaseWithTypeModel()
        {
            return new ReportModelBase<SportTypeModel>
            {
                Entities = new List<SportTypeModel>(),
                Total = new SportTypeModel()
            };
        }

        private ViewModelJson CreateEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                Entities = new List<SportTypeModel>(),
                Total = new SportTypeModel()
            };
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReportModelBase<SportTypeModel>, ViewModelJson>(MemberList.Source);
                cfg.CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }

        [Test]
        public async Task Handle_ServiceReturnsNonEmptyModelBaseWithSportType_ReturnsNonEmptyViewModelJson()
        {
            // Arrange
            var nonEmptyModelBaseWithSportTypeModel = CreateNonEmptyModelBaseWithSportTypeModel();
            var service = Substitute.For<PunterAnalysisService>();
            service.Query<SportTypeModel>(Arg.Any<ICriteria>()).Returns(nonEmptyModelBaseWithSportTypeModel);

            var mapper = CreateMapper();

            // Act
            var handler = new Handler(mapper, service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateNonEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ReportModelBase<SportTypeModel> CreateNonEmptyModelBaseWithSportTypeModel()
        {
            return new ReportModelBase<SportTypeModel>
            {
                Entities = new List<SportTypeModel> { CreateSportTypeModel() },
                Total = CreateSportTypeModel()
            };
        }

        private ViewModelJson CreateNonEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                Entities = new List<SportTypeModel> { CreateSportTypeModel() },
                Total = CreateSportTypeModel()
            };
        }

        private SportTypeModel CreateSportTypeModel()
        {
            return new SportTypeModel
            {
                SportName = "Sport 1",
                WinLoss = 100,
                Turnover = 200,
                BetCount = 2
            };
        }
    }
}
