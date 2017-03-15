using Fanex.NAP.Core.Models;
using Fanex.NAP.Core.Web.Session;
using System;
using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Tests.Mocks
{
    public class CurrentSessionMock : ICurrentSession
    {
        public int Level
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<MenuItem> MenuItemList
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int OnUserId
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string SessionId
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int UserId
        {
            get
            {
                return 1;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Username
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void ClearAll()
        {
            throw new NotImplementedException();
        }
    }
}
