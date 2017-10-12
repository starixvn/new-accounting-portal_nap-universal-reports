using System.Collections.Generic;
using MediatR;

namespace UniversalReports.PunterAnalysis.AssociatedAccount.Model
{
    public class HttpParameterJson : IRequest<List<UserRoleModel>>
    {
        public int CustId { get; set; }

        public string Username { get; set; }
    }
}