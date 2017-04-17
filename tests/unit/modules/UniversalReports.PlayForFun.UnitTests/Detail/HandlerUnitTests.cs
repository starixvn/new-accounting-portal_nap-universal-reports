using AutoMapper;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Detail;
using UniversalReports.PlayForFun.Detail.Model;

namespace UniversalReports.PlayForFun.UnitTests.Detail
{
    public class HandlerUnitTests
    {
        [Test]
        public async Task Handle_ServiceReturnsEmptyModelBaseWithDetail_ReturnsEmptyViewModelJson()
        {
            // Arrange
            var emptyModelBaseWithDetail = CreateEmptyModelBaseWithTypeModel();
            var service = Substitute.For<PlayForFunService>();
            service.Query<DetailModel>(Arg.Any<ICriteria>()).Returns(emptyModelBaseWithDetail);

            var mapper = CreateMapper();

            // Act
            var handler = new Handler(mapper, service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ReportModelBase<DetailModel> CreateEmptyModelBaseWithTypeModel()
        {
            return new ReportModelBase<DetailModel>
            {
                Entities = new List<DetailModel>(),
                Total = new DetailModel()
            };
        }

        private ViewModelJson CreateEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                Entities = new List<DetailModel>(),
                Total = new DetailModel()
            };
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReportModelBase<DetailModel>, ViewModelJson>(MemberList.Source);
                cfg.CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }

        [Test]
        public async Task Handle_ServiceReturnsNonEmptyModelBaseWithDetail_ReturnsNonEmptyViewModelJson()
        {
            // Arrange
            var nonEmptyModelBaseWithDetailModel = CreateNonEmptyModelBaseWithDetailModel();
            var service = Substitute.For<PlayForFunService>();
            service.Query<DetailModel>(Arg.Any<ICriteria>()).Returns(nonEmptyModelBaseWithDetailModel);

            var mapper = CreateMapper();

            // Act
            var handler = new Handler(mapper, service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateNonEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ReportModelBase<DetailModel> CreateNonEmptyModelBaseWithDetailModel()
        {
            return new ReportModelBase<DetailModel>
            {
                Entities = new List<DetailModel> { CreateDetailModel() },
                Total = CreateDetailModel()
            };
        }

        private ViewModelJson CreateNonEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                Entities = new List<DetailModel> { CreateDetailModel() },
                Total = CreateDetailModel()
            };
        }

        private DetailModel CreateDetailModel()
        {
            return new DetailModel
            {
                Username = "User 1",
                WinLoss = 100,
                Turnover = 200,
                BetCount = 2
            };
        }
    }
}
