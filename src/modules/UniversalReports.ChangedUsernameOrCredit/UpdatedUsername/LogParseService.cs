using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedUsername
{
    public interface LogParseService
    {
        UsernameLogModel GetUsernameLog(string tracking);
    }

    public class LogParseServiceImp : LogParseService
    {
        public UsernameLogModel GetUsernameLog(string tracking)
        {
            var xElement = XElement.Parse(tracking);

            return new UsernameLogModel
            {
                FromName = xElement.Attribute("FromName").Value,
                ToName = xElement.Attribute("ToName").Value
            };
        }
    }
}
