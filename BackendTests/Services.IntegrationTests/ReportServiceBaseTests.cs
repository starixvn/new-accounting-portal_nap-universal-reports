using Fanex.Data.Configuration;
using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services;
using NUnit.Framework;

namespace NAP.Reports.Services.Tests
{
    public class ReportServiceBaseTests
    {
        private BalanceUpRange _balanceUpRange;

        private MainReportQuery _mainReportQuery;

        public BalanceUpRange BalanceUpRange
        {
            get
            {
                return _balanceUpRange;
            }

            set
            {
                _balanceUpRange = value;
            }
        }

        public MainReportQuery MainReportQuery
        {
            get
            {
                return _mainReportQuery;
            }

            set
            {
                _mainReportQuery = value;
            }
        }

        [SetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();

            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpService(dynamicRepository);

            _balanceUpRange = balanceUpService.Query();
            _mainReportQuery = new MainReportQuery
            {
                StartDate = _balanceUpRange.BalanceUpDate.AddDays(-2),
                EndDate = _balanceUpRange.MoveBetsDate.AddDays(2)
            };
        }
    }
}
