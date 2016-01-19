using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services;

namespace NAP.Reports.Services.Tests
{
    public class BaseWinLossServiceTests
    {
        protected IRawWinLossService CreateRawWinLossService()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpService(dynamicRepository);
            var balanceUpSourceChooser = new BalanceUpSourceChooser(balanceUpService);

            var calculationService = new CalculationService();
            return new RawWinLossService(dynamicRepository, calculationService, balanceUpSourceChooser);
        }

        protected BalanceUpRange GetBalanceUpRange()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpService(dynamicRepository);
            return balanceUpService.Query();
        }
    }
}
