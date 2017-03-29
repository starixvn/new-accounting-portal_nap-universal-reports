using Fanex.NAP.Core.Models;
using Fanex.NAP.Core.Web.Session;
using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Tests.Mocks
{
    public class CurrentSessionMock : ICurrentSession
    {
        public int Level
        {
            get;
            set;
        }

        public IList<MenuItem> MenuItemList
        {
            get;
            set;
        }

        public int OnUserId
        {
            get;
            set;
        }

        public string SessionId
        {
            get;
            set;
        }

        public int UserId
        {
            get
            {
                return 1;
            }

            set
            {
            }
        }

        public string Username
        {
            get;
            set;
        }

        public void ClearAll()
        {
        }
    }
}
