using System;
using System.Configuration;

namespace UniversalReports.Core.Configurations
{
    public interface ConfigurationService
    {
        string FraudSystemApi { get; }

        string CurrentDirectory { get; }
    }

    public class ConfigurationServiceImp : ConfigurationService
    {
        public string FraudSystemApi => ConfigurationManager.AppSettings["FraudSystemAPI"];

        public string CurrentDirectory => AppDomain.CurrentDomain.BaseDirectory;
    }
}