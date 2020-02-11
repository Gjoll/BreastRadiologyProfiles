using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface ISectionList
    {
        Int32 Min { get; }
        Int32 Max { get; }

        String Title { get; }
        CodeableConcept Code { get; }
    }

    public class SectionList<T> : ISectionList
        where T : IResourceBase
    {
        public CodeableConcept Code { get; }
        public String Title { get; }
        public Int32 Min { get; }
        public Int32 Max { get; }
        List<T> items = new List<T>();

        public SectionList(CodeableConcept code,
            String title,
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
