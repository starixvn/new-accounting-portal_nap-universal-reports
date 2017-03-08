using AutoMapper;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.AssociatedAccount;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.UnitTests.AssociatedAccount
{
    public class HandlerUnitTests
    {
        [Test]
        public async Task Handle_ServiceReturnsEmptyModelBaseWithAssociatedAccount_ReturnsEmptyViewModelJson()
        {
            // Arrange
            var emptyModelBaseWithAssociatedAccount = CreateEmptyModelBaseWithTypeModel();
            var service = Substitute.For<PunterAnalysisService>();
            service.Query<AssociatedAccountModel>(Arg.Any<ICriteria>()).Returns(emptyModelBaseWithAssociatedAccount);

            var mapper = CreateMapper();

            // Act
            var handler = new Handler(mapper, service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ModelBase<AssociatedAccountModel> CreateEmptyModelBaseWithTypeModel()
        {
            return new ModelBase<AssociatedAccountModel>
            {
                Entities = new List<AssociatedAccountModel>(),
                Total = new AssociatedAccountModel()
            };
        }

        private ViewModelJson CreateEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                Entities = new List<AssociatedAccountModel>(),
                Total = new AssociatedAccountModel()
            };
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ModelBase<AssociatedAccountModel>, ViewModelJson>();
                cfg.CreateMap<HttpParameterJson, Criteria>();
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }

        [Test]
        public async Task Handle_ServiceReturnsNonEmptyModelBaseWithAssociatedAccount_ReturnsNonEmptyViewModelJson()
        {
            // Arrange
            var nonEmptyModelBaseWithAssociatedAccountModel = CreateNonEmptyModelBaseWithAssociatedAccountModel();
            var service = Substitute.For<PunterAnalysisService>();
            service.Query<AssociatedAccountModel>(Arg.Any<ICriteria>()).Returns(nonEmptyModelBaseWithAssociatedAccountModel);

            var mapper = CreateMapper();

            // Act
            var handler = new Handler(mapper, service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            var expected = CreateNonEmptyViewModelJson();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ModelBase<AssociatedAccountModel> CreateNonEmptyModelBaseWithAssociatedAccountModel()
        {
            return new ModelBase<AssociatedAccountModel>
            {
                Entities = new List<AssociatedAccountModel> { CreateAssociatedAccountModel() },
                Total = CreateAssociatedAccountModel()
            };
        }

        private ViewModelJson CreateNonEmptyViewModelJson()
        {
            return new ViewModelJson
            {
                Entities = new List<AssociatedAccountModel> { CreateAssociatedAccountModel() },
                Total = CreateAssociatedAccountModel()
            };
        }

        private AssociatedAccountModel CreateAssociatedAccountModel()
        {
            return new AssociatedAccountModel
            {
                Username = "User 1",
                WinLoss = 100,
                Turnover = 200,
                BetCount = 2
            };
        }
    }
}
