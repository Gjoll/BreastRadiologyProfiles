using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface IMemberList
    {
        Int32 Min { get; }
        Int32 Max { get; }
    }

    public class MemberList<T> : IMemberList
        where T : IBaseBase
    {
        public Int32 Min { get; }
        public Int32 Max { get; }
        List<T> items = new List<T>();

        public MemberList(Int32 min, Int32 max)
        {
            this.Min = min;
            this.Max = max;
        }

        public void Write(Observation resource)
        {
            foreach (T item in items)
            {
                resource.HasMember.Add(new ResourceReference(item.Id));
            }
        }
    }
}
