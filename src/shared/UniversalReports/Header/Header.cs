namespace UniversalReports.Header
{
    using System.Collections.Generic;
    using System.Configuration;

    public class Header
    {
        public string LegacyPath { get; } = ConfigurationManager.AppSettings["LegacyPath"];

        public string Username { get; set; }

        public IList<Menu> Menus { get; set; }
    }
}