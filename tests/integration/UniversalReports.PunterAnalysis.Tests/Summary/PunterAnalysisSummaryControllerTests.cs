using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.Summary;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.Tests.Summary
{
    public class PunterAnalysisSummaryControllerTests
    {
        [Test]
        public async Task Index_Always_CallMediatorSend()
        {
            // Arrange            
            var viewModelJson = new ViewModelJson
            {
                Entities = CreateSummaryModelList(),
                Total = CreateSummaryModelTotal()
            };

            var mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<HttpParameterJson>()).Returns(viewModelJson);

            // Act
            var controller = new PunterAnalysisSummaryController(mediator);
            var result = controller.Index(Arg.Any<HttpParameterJson>());

            // Assert

        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ModelBase<SummaryModel>, ViewModelJson>();
                cfg.CreateMap<HttpParameterJson, Criteria>();
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }

        private List<SummaryModel> CreateSummaryModelList()
        {
            return new List<SummaryModel>
            {
                new SummaryModel { UserName = "user1", WinLoss = 1000, Turnover = 500, BetCount = 1 },
                new SummaryModel { UserName = "user2", WinLoss = 1000, Turnover = 500, BetCount = 1 },
            };
        }

        private SummaryModel CreateSummaryModelTotal()
        {
            return new SummaryModel { WinLoss = 2000, Turnover = 1000, BetCount = 2 };
        }
    }
}