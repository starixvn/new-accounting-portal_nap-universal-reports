using AutoMapper;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetCount;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.UnitTests.BetCount
{
    public class HandlerUnitTests
    {
        [Test]
        public async Task Handle_ServiceReturnsEmptyModelBaseWithBetCount_ReturnsEmptyViewModelJson()
        {
            // Arrange
            var emptyModelBaseWithBetCount = CreateEmptyModelBaseWithTypeModel();
            var service = Substitute.For<PunterAnalysisService>();
            service.Query<BetCountModel>(Arg.Any<ICriteria>()).Returns(emptyModelBaseWithBetCount);

            var mapper = CreateMapper();

            // Act
            var handler = new Handler(mapper, service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ReportModelBase<BetCountModel> CreateEmptyModelBaseWithTypeModel()
        {
            return new ReportModelBase<BetCountModel>
            {
                Entities = new List<BetCountModel>(),
                Total = new BetCountModel()
            };
        }

        private ViewModelJson CreateEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                Entities = new List<BetCountModel>(),
                Total = new BetCountModel()
            };
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReportModelBase<BetCountModel>, ViewModelJson>(MemberList.Source);
                cfg.CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }

        [Test]
        public async Task Handle_ServiceReturnsNonEmptyModelBaseWithBetCount_ReturnsNonEmptyViewModelJson()
        {
            // Arrange
            var nonEmptyModelBaseWithBetCountModel = CreateNonEmptyModelBaseWithBetCountModel();
            var service = Substitute.For<PunterAnalysisService>();
            service.Query<BetCountModel>(Arg.Any<ICriteria>()).Returns(nonEmptyModelBaseWithBetCountModel);

            var mapper = CreateMapper();

            // Act
            var handler = new Handler(mapper, service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateNonEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ReportModelBase<BetCountModel> CreateNonEmptyModelBaseWithBetCountModel()
        {
            return new ReportModelBase<BetCountModel>
            {
                Entities = new List<BetCountModel> { CreateBetCountModel() },
                Total = CreateBetCountModel()
            };
        }

        private ViewModelJson CreateNonEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                Entities = new List<BetCountModel> { CreateBetCountModel() },
                Total = CreateBetCountModel()
            };
        }

        private BetCountModel CreateBetCountModel()
        {
            return new BetCountModel
            {
                BetCount = 1,
                DrawCount = 1,
                WinCount = 1,
                WinLoss = 100,
                Date = DateTime.MinValue
            };
        }
    }
}
