using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Olympus.WebApi.Epplus;
using SimpleInjector;
using UniversalReports.ActualMemberBet.Bettype;
using UniversalReports.ActualMemberBet.Tests.DependencyInjection;

namespace UniversalReports.ActualMemberBet.Tests.Bettype
{
    public class ActualMemberBetBettypeControllerTests
    {
        private const string FakeRepositoryDataFileName = "Bettype-ActualMemberBet-FileRepository.json";

        [Test]
        public async Task Excel_FileRepository_ReturnsRightExcelPackage()
        {
            // Arrange
            var expectedTitle = TestDataLoader.Load<object[,]>("Bettype-ActualMemberBet-Excel-ExpectedTitle.json");
            var expectedBody = TestDataLoader.Load<object[,]>("Bettype-ActualMemberBet-Excel-ExpectedBody.json");
            var expectedTotal = TestDataLoader.Load<object[,]>("Bettype-ActualMemberBet-Excel-ExpectedTotal.json");


            var container = new Container();
            var factory = new ApiControllerFactoryMethodFetchAsync(container);
            var controller = factory.CreateController<ActualMemberBetBettypeController, BetTypeActualMemberBet>(FakeRepositoryDataFileName);

            // Act
            var httpActionResult = await controller.Excel(new HttpParameterExcel
            {
                FromDate = new DateTime(2018, 9, 1),
                ToDate = new DateTime(2018, 9, 20),
                CurrencyId = -9999,
                SiteType = -9999,
                OddsType = "1",
                KeyId = "1#2#1",
                ProductName = "Soccer Major"
            });

            var excelPackage = (httpActionResult as EpplusExcelResult).ExcelPackage;
            var actualMemberBetWorkSheet = excelPackage.Workbook.Worksheets[1];

            // Assert
            Assert.That(actualMemberBetWorkSheet.Name, Is.EqualTo("ActualMemberBet"));

            Assert.That(actualMemberBetWorkSheet.Cells["A1:I1"].Value, Is.EqualTo(expectedTitle));
            Assert.That(actualMemberBetWorkSheet.Cells["A5:I6"].Value, Is.EqualTo(expectedBody));
            Assert.That(actualMemberBetWorkSheet.Cells["A7:I7"].Value, Is.EqualTo(expectedTotal));

            // Release
            container.Dispose();
        }
    }
}
