using System;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.Core.Configurations;
using UniversalReports.UpdatedUsernameCredit.Common;
using UniversalReports.UpdatedUsernameCredit.UpdatedCredit;

namespace UniversalReports.UpdatedUsernameCredit.UnitTests.UpdatedCredit
{
    [TestFixture]
    public class UpdatedCreditExcelSettingFactoryTests
    {
        [Test]
        public void CreateSetting_WithMessage_ReturnRightUpdatedCreditExcelSetting()
        {
            // Arrange
            var configurationService = Substitute.For<ConfigurationService>();
            configurationService.CurrentDirectory.Returns("D:");
            var expectedExcelSetting = new ExcelSetting
            {
                SheetName = "Updated Credit",
                StartRowIndex = 5,
                TemplatePath = "D:\\ExcelTemplate\\UpdatedUsernameAndCredit\\UpdatedCredit.xlsx",
                Title = "Updated Credit report From Oct 01, 2017 To Oct 20, 2017",
                TitleCellRange = "A1:O2"
            };

            var setting = new UpdatedCreditExcelSettingFactory(configurationService);

            // Act
            var result = setting.CreateSetting(
                new BaseMessage
                {
                    FromDate = new DateTime(2017, 10, 1),
                    ToDate = new DateTime(2017, 10, 20),
                    Username = string.Empty
                });

            // Assert
            Assert.That(result, IsDeeplyEqual.To(expectedExcelSetting));
        }
    }
}
