using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface IConfiguration
    {
        List<string> Products { get; }
    }
}