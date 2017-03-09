using System.Configuration;

namespace UniversalReports.Core.Configurations
{
    public interface ApplicationConfigurationService
    {
        string FraudSystemAPI { get; }
    }

    public class ApplicationConfigurationServiceImp : ApplicationConfigurationService
    {
        public string FraudSystemAPI => ConfigurationManager.AppSettings["FraudSystemAPI"];
    }
}
