using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.UserName
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(UserNameModel userNameModel, string title);
    }
}