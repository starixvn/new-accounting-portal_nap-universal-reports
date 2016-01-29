using Fanex.Data.Repository;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Tests.Common
{
    public class BaseServiceTests
    {
        protected virtual RawService CreateRawWinLossService()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpServiceImp(dynamicRepository);
            var balanceUpSourceChooser = new BalanceUpSourceChooserImp(balanceUpService);

            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            return new RawServiceImp(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);
        }

        protected BalanceUpRange GetBalanceUpRange()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpServiceImp(dynamicRepository);
            return balanceUpService.Query();
        }
    }
}
