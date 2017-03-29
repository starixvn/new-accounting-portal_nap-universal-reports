using System;

namespace UniversalReports.EpplusTemplate.Annotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CellShiftAttribute : Attribute
    {
        public CellShiftAttribute(string address)
        {
            Address = address;
        }

        public string Address { get; }
    }
}
