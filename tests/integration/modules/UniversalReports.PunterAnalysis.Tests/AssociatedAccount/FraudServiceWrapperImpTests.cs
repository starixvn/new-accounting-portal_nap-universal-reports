using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.AssociatedAccount;

namespace UniversalReports.PunterAnalysis.Tests.AssociatedAccount
{
    public class FraudServiceWrapperImpTests
    {
        [Test]
        public async Task GetAssociatedCustomerByDevice_ReturnsListOfCustomerDevice()
        {
            // Arrage
            var applicationConfigurationService = Substitute.For<ApplicationConfigurationService>();
            applicationConfigurationService.FraudSystemApi.Returns("http://ha.nexdev.net:7704");
            var fraudService = new FraudServiceWrapperImp(applicationConfigurationService);

            // Act
            await fraudService.GetAssociatedUsers("username", "site");
        }
    }
}
