using AutoMapper;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.UnitTests.MapperTests
{
    public class MapperUnitTests
    {
        [Test]
        public void Map_EmptyModelBaseOfBetCountModel_CanMapToEmptyViewModelJsonOfBetCountModel()
        {
            // Arrange
            var modelBase = CreateEmptyModelBase();

            // Act
            var mapper = CreateMapper();
            var viewModel = mapper.Map<ViewModelJson>(modelBase);

            // Assert
            Assert.That(viewModel, Is.Not.Null);
            Assert.That(viewModel.Entities.Count, Is.EqualTo(0));
            Assert.That(viewModel.Entities, Is.Not.Null);
        }

        [Test]
        public void Map_ModelBaseWithOneBetCountModel_CanMapToViewModelJsonWithOneBetCountModel()
        {
            // Arrange
            var modelBase = CreateModelBaseWithOneBetCountModel();

            // Act
            var mapper = CreateMapper();
            var viewModel = mapper.Map<ViewModelJson>(modelBase);

            // Assert
            var expected = CreateViewModelJsonWithOneBetCountModel();
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ModelBase<BetCountModel> CreateEmptyModelBase()
        {
            return new ModelBase<BetCountModel>
            {
                Entities = new List<BetCountModel> { },
                Total = new BetCountModel()
            };
        }

        private ModelBase<BetCountModel> CreateModelBaseWithOneBetCountModel()
        {
            return new ModelBase<BetCountModel>
            {
                Entities = new List<BetCountModel>
                {
                    CreateBetCountModel()
                },
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

        private ViewModelJson CreateViewModelJsonWithOneBetCountModel()
        {
            return new ViewModelJson
            {
                Entities = new List<BetCountModel> { CreateBetCountModel() },
                Total = CreateBetCountModel()
            };
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ModelBase<BetCountModel>, ViewModelJson>();
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }
    }
}
