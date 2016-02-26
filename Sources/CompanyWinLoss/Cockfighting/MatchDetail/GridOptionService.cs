using Fanex.Excel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public interface GridOptionService
    {
        GridOptions FromWinLossModel(WinLossModel winloss);
    }
}
