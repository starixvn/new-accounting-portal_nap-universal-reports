using AutoMapper;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.League;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.League
{
    public class HandlerUnitTests
    {
        [Test]
        public async Task Handle_ServiceReturnsEmptyModelBaseWithLeague_ReturnsEmptyViewModelJson()
        {
            // Arrange
            var mapper = CreateMapper();

            var emptyReportModel = CreateEmptyReportModel();
            var factory = CreateLeagueServiceFactory(emptyReportModel);

            // Act
            var handler = new Handler(mapper, factory);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ReportModel CreateEmptyReportModel()
        {
            return new ReportModel
            {
                GroupNames = new List<string>(),
                Entities = new List<LeagueModel>(),
                Total = new LeagueModel()
            };
        }

        private ViewModelJson CreateEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                Entities = new List<LeagueModel>(),
                Total = new LeagueModel()
            };
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReportModel, ViewModelJson>(MemberList.Source);
                cfg.CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }

        private LeagueServiceFactory CreateLeagueServiceFactory(ReportModel reportModel)
        {
            var service = Substitute.For<LeagueService>();
            service.Query(Arg.Any<ICriteria>()).Returns(reportModel);

            var factory = Substitute.For<LeagueServiceFactory>();
            factory.CreateLeagueService(Arg.Any<int>()).Returns(service);

            return factory;
        }

        [Test]
        public async Task Handle_ServiceReturnsNonEmptyModelBaseWithLeague_ReturnsNonEmptyViewModelJson()
        {
            // Arrange
            var mapper = CreateMapper();

            var nonEmptyReportModel = CreateNonEmptyReportModel();
            var factory = CreateLeagueServiceFactory(nonEmptyReportModel);

            // Act
            var handler = new Handler(mapper, factory);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateNonEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ReportModel CreateNonEmptyReportModel()
        {
            return new ReportModel
            {
                Entities = new List<LeagueModel> { CreateLeagueModel() },
                Total = CreateLeagueModel()
            };
        }

        private ViewModelJson CreateNonEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                GroupNames = new List<string>(),
                Entities = new List<LeagueModel> { CreateLeagueModel() },
                Total = CreateLeagueModel()
            };
        }

        private LeagueModel CreateLeagueModel()
        {
            return new LeagueModel
            {
                LeagueName = "Bet Type 1",
                PeriodGroups = new List<PeriodGroup>()
            };
        }
    }
}