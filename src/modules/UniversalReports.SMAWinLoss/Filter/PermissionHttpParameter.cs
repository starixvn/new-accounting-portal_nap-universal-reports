using MediatR;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class PermissionHttpParameter : IRequest<int>
    {
        public string FunctionKey { get; set; }
    }
}
