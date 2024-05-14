using MediatR;
using System.Collections.Generic;
using UniversalReports.ResultAnalysis.Models;

namespace UniversalReports.ResultAnalysis.Requests
{
	public class LeagueRequest: IRequest<IEnumerable<LeagueModel>>
	{
		public int SportId { get; set; }

		public string SearchText { get; set; }
	}
}
