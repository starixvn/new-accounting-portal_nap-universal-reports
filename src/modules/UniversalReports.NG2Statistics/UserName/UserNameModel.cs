using System.Collections.Generic;
using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.UserName
{
    public class UserNameModel : BaseModel
    {
        public UserNameModel()
        {
            Rows = new List<UserNameModel>();
        }

        public string Username { get; set; }

        public int CustId { get; set; }

        public List<UserNameModel> Rows { get; set; }

        public UserNameModel Total { get; set; }
    }
}