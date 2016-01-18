namespace NAP.Reports.CompanyWinLoss.Services.Criteria
{
    public class NumberGameWinLossCriteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-NumberGame-{Source}";
        }

    }
}
