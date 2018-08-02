using System;
using System.Configuration;
using Fanex.RemotingRef;

namespace UniversalReports.Sites
{
    public static class RemotingRef
    {
        public static void Register()
        {
            RefDataTypeContainer
                .ConnectTo(new Uri(ConfigurationManager.AppSettings["RemoteRefURL"]))
                .FromApplication("Universal Reports")
                .SupportOnlyDefaultLanguage();

        }
    }
}