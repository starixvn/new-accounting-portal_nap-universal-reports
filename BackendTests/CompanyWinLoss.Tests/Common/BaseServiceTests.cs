using Fanex.Data.Repository;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Tests.Common
{
    public abstract class BaseServiceTests : BaseSetupServiceTests
    {
        protected virtual RawWinLossService CreateRawWinLossService()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpServiceImp(dynamicRepository);
            var balanceUpSourceChooser = new BalanceUpSourceChooserImp(balanceUpService);

            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            return new RawWinLossServiceImp(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);
        }

        protected BalanceUpRange GetBalanceUpRange()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpServiceImp(dynamicRepository);
            return balanceUpService.Query();
        }

        protected abstract WinLossCriteria CreateCriteria();
    }
}
