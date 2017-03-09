using AutoMapper;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.Summary;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.Summary
{
    public class HandlerUnitTests
    {
        [Test]
        public async Task Handle_ServiceReturnsEmptyModelBaseWithSummary_ReturnsEmptyViewModelJson()
        {
            // Arrange
            var emptyModelBaseWithSummary = CreateEmptyModelBaseWithTypeModel();
            var service = Substitute.For<PunterAnalysisService>();
            service.Query<SummaryModel>(Arg.Any<ICriteria>()).Returns(emptyModelBaseWithSummary);

            var mapper = CreateMapper();

            // Act
            var handler = new Handler(mapper, service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ReportModelBase<SummaryModel> CreateEmptyModelBaseWithTypeModel()
        {
            return new ReportModelBase<SummaryModel>
            {
                Entities = new List<SummaryModel>(),
                Total = new SummaryModel()
            };
        }

        private ViewModelJson CreateEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                Entities = new List<SummaryModel>(),
                Total = new SummaryModel()
            };
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReportModelBase<SummaryModel>, ViewModelJson>(MemberList.Source);
                cfg.CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }

        [Test]
        public async Task Handle_ServiceReturnsNonEmptyModelBaseWithSummary_ReturnsNonEmptyViewModelJson()
        {
            // Arrange
            var nonEmptyModelBaseWithSummaryModel = CreateNonEmptyModelBaseWithSummaryModel();
            var service = Substitute.For<PunterAnalysisService>();
            service.Query<SummaryModel>(Arg.Any<ICriteria>()).Returns(nonEmptyModelBaseWithSummaryModel);

            var mapper = CreateMapper();

            // Act
            var handler = new Handler(mapper, service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateNonEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ReportModelBase<SummaryModel> CreateNonEmptyModelBaseWithSummaryModel()
        {
            return new ReportModelBase<SummaryModel>
            {
                Entities = new List<SummaryModel> { CreateSummaryModel() },
                Total = CreateSummaryModel()
            };
        }

        private ViewModelJson CreateNonEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                Entities = new List<SummaryModel> { CreateSummaryModel() },
                Total = CreateSummaryModel()
            };
        }

        private SummaryModel CreateSummaryModel()
        {
            return new SummaryModel
            {
                Username = "User 1",
                WinLoss = 100,
                Turnover = 200,
                BetCount = 2
            };
        }
    }
}
