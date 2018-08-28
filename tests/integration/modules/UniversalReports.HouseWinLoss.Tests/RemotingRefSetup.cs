using System;
using System.Configuration;
using Fanex.RemotingRef;
using NUnit.Framework;

[SetUpFixture]
public class RemotingRefSetup
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        RefDataTypeContainer
                .ConnectTo(new Uri(ConfigurationManager.AppSettings["Fanex.RemotingRef.Service.Url"]))
                .FromApplication("NAP - Reports - Universal")
                .SupportOnlyDefaultLanguage();
    }
}


