using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistics.UserName
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(UserNameModel userNameModel, string title);
    }
}