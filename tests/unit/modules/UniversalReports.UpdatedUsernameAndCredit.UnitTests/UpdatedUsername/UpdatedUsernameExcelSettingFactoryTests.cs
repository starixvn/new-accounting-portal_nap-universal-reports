using System;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.Core.Configurations;
using UniversalReports.UpdatedUsernameCredit.Common;
using UniversalReports.UpdatedUsernameCredit.UpdatedUsername;

namespace UniversalReports.UpdatedUsernameCredit.UnitTests.UpdatedUsername
{
    [TestFixture]
    public class UpdatedUsernameExcelSettingFactoryTests
    {
        [Test]
        public void CreateSetting_WithMessage_ReturnRight_UpdatedUsernameExcelSetting()
        {
            // Arrange
            var configurationService = Substitute.For<ConfigurationService>();
            configurationService.CurrentDirectory.Returns("D:");
            var expectedExcelSetting = new ExcelSetting
            {
                SheetName = "Updated Username",
                StartRowIndex = 5,
                TemplatePath = "D:\\ExcelTemplate\\UpdatedUsernameAndCredit\\UpdatedUsername.xlsx",
                Title = "Updated Username report From Oct 01, 2017 To Oct 20, 2017",
                TitleCellRange = "A1:N2"
            };

            var setting = new UpdatedUsernameExcelSettingFactory(configurationService);

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
