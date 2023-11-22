namespace UniversalReports.Configurations
{
    using System;
    using System.Configuration;

    public interface ConfigurationService
    {
        string FraudSystemApi { get; }

        string CurrentDirectory { get; }

        string SMAWLPath { get; }

        string FraudSystemCategoryApi { get; }
    }

    public class ConfigurationServiceImp : ConfigurationService
    {
        public string FraudSystemApi => ConfigurationManager.AppSettings["FraudSystemAPI"];

        public string CurrentDirectory => AppDomain.CurrentDomain.BaseDirectory;

        public string SMAWLPath => ConfigurationManager.AppSettings["SMAWLPath"];

        public string FraudSystemCategoryApi => ConfigurationManager.AppSettings["FraudSystemCategoryAPI"];
    }
}