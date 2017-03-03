using AutoMapper;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.UnitTests.MapperTests
{
    public class MapperUnitTests
    {
        [Test]
        public void Map_EmptyModelBaseOfBetTypeModel_CanMapToEmptyViewModelJsonOfBetTypeModel()
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
        public void Map_ModelBaseWithOneBetTypeModel_CanMapToViewModelJsonWithOneBetTypeModel()
        {
            // Arrange
            var modelBase = CreateModelBaseWithOneBetTypeModel();
            var expected = CreateViewModelJsonWithOneBetTypeModel();

            // Act
            var mapper = CreateMapper();
            var viewModel = mapper.Map<ViewModelJson>(modelBase);

            // Assert
            Assert.That(viewModel, IsDeeplyEqual.To(expected));
        }

        private ModelBase<BetTypeModel> CreateEmptyModelBase()
        {
            return new ModelBase<BetTypeModel>
            {
                Entities = new List<BetTypeModel> { },
                Total = new BetTypeModel()
            };
        }

        private ModelBase<BetTypeModel> CreateModelBaseWithOneBetTypeModel()
        {
            return new ModelBase<BetTypeModel>
            {
                Entities = new List<BetTypeModel>
                {
                    CreateBetTypeModel()
                },
                Total = CreateBetTypeModel()
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

        private ViewModelJson CreateViewModelJsonWithOneBetTypeModel()
        {
            return new ViewModelJson
            {
                Entities = new List<BetTypeModel> { CreateBetTypeModel() },
                Total = CreateBetTypeModel()
            };
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ModelBase<BetTypeModel>, ViewModelJson>();
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }
    }
}
