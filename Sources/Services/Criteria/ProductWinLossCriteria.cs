namespace NAP.Reports.CompanyWinLoss.Services.Criteria
{
    public class ProductWinLossCriteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Products-{Source}";
        }

    }
}
