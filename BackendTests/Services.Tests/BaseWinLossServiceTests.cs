using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services;

namespace NAP.Reports.Services.Tests
{
    public class BaseWinLossServiceTests
    {
        protected RawWinLossService CreateRawWinLossService()
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
    }
}
