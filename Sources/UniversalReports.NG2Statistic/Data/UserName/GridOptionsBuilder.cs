using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data.UserName
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(UserNameModel userNameModel, string title);
    }
}