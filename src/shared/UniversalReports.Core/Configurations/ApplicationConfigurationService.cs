using System.Configuration;

namespace UniversalReports.Core.Configurations
{
    public interface ApplicationConfigurationService
    {
        string FraudSystemApi { get; }
    }

    public class ApplicationConfigurationServiceImp : ApplicationConfigurationService
    {
        public string FraudSystemApi => ConfigurationManager.AppSettings["FraudSystemAPI"];
    }
}
