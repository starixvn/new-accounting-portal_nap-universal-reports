//using Fanex.Data.Repository;
//using NSubstitute;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UniversalReports.PunterAnalysis.BetType;
//using UniversalReports.PunterAnalysis.BetType.Model;
//using UniversalReports.PunterAnalysis.Core;

//namespace UniversalReports.PunterAnalysis.UnitTests.BetType
//{
//    public class HandlerUnitTests
//    {

//        [OneTimeSetUp]
//        public void Setup()
//        {

//        }

//        [Test]
//        public void Handle_PunterAnalysisServiceReturnsEmptyEntities_HandlerReturnsEmptyResult()
//        {
//            // Arrange
//            var emptyEntities = new List<BetTypeModel>();
//            var punterAnalysisService = Substitute.For<PunterAnalysisService>();
//            punterAnalysisService.Query<ModelBase<BetTypeModel>>(Arg.Any<ICriteria>()).Returns(emptyEntities);

//            // Act
//            var handler = new Handler()
//        }
//    }
//}
