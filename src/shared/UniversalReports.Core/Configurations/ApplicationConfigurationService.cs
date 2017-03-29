using System;
using System.Configuration;

namespace UniversalReports.Core.Configurations
{
    public interface ApplicationConfigurationService
    {
        string FraudSystemApi { get; }

        string CurrentDirectory { get; }
    }

    public class ApplicationConfigurationServiceImp : ApplicationConfigurationService
    {
        public string FraudSystemApi => ConfigurationManager.AppSettings["FraudSystemAPI"];

        public string CurrentDirectory => AppDomain.CurrentDomain.BaseDirectory;
    }
}
