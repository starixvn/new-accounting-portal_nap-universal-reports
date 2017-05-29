using NUnit.Framework;
using System;
using UniversalReports.Core.Configurations;

namespace UniversalReports.Core.Tests.Configurations
{
    public class ApplicationConfigurationServiceTests
    {
        [Test]
        public void FraudSystemApi_Always_ReturnsRightConfigurationData()
        {
            // Arrange
            var configurationService = new ApplicationConfigurationServiceImp();

            // Assert
            Assert.That(configurationService.FraudSystemApi, Is.EqualTo("http://google.com/api"));
        }

        public void CurrentDirectory_Always_ReturnsCurrentDomainBaseDirectory()
        {
            // Arrange
            var configurationService = new ApplicationConfigurationServiceImp();

            // Assert
            Assert.That(configurationService.FraudSystemApi, Is.EqualTo(AppDomain.CurrentDomain.BaseDirectory));
        }
    }
}
