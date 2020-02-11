using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public class SectionList<T>
        where T : class
    {
        public Coding Code { get; }
        public String Title { get; }
        public Int32 Min { get; }
        public Int32 Max { get; }
        List<T> items = new List<T>();

        public SectionList(String title,
            Coding code,
            Int32 min,
            Int32 max)
        {
            this.Min = min;
            this.Max = max;
            this.Code = code;
            this.Title = title;
        }

        public void Write(Composition resource)
        {
            foreach (T item in items)
            {
                //resource.HasMember.Add(new ResourceReference(item.Id));
            }
        }
    }
}
