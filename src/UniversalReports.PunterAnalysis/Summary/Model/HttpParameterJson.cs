using System;
using MediatR;

namespace UniversalReports.PunterAnalysis.Summary.Model
{
    public class HttpParameterJson : IRequest<ViewModelJson>
    {
        public int TopRow { get; set; }

        public short OrderBy { get; set; }

        public short ShortBy { get; set; }

        public short PeriodType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public short Dept { get; set; }

        public string UserName { get; set; }

        public string LstCombinationID { get; set; }
    }
}