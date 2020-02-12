using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface ICompositionBase : IResourceBase
    {
    }

    public abstract class CompositionBase : ResourceBase, ICompositionBase
    {
        public Composition Resource => (Composition)this.resource;

        public CompositionBase(Composition resource) : base(resource)
        {
        }

        public CompositionBase() : base()
        {
        }
        protected void ClearSection()
        {
            this.Resource.Section.Clear();
        }


        Composition.SectionComponent FindSection(Coding code)
        {

            bool IsCode(CodeableConcept sectionCode)
            {
                foreach (Coding c in sectionCode.Coding)
                {
                    if (
                        (String.Compare(c.System, code.System, true) == 0) &&
                        (String.Compare(c.Code, code.Code, true) == 0)
                        )
                        return true;
                }
                return false;
            }

            foreach (Composition.SectionComponent section in this.Resource.Section)
            {
                if (IsCode(section.Code))
                    return section;
            }
            return null;
        }

        protected void ReadSection<T>(ResourceBag resourceBag,
            Coding code,
            Int32 min,
            Int32 max,
            List<T> items)
            where T : ResourceBase, new()
        {
            items.Clear();
            Composition.SectionComponent section = this.FindSection(code);
            if (section == null)
                throw new Exception($"Error referencing section '{code.ToString()}'");

            foreach (ResourceReference resRef in section.Entry)
            {
                if (resourceBag.TryGetEntry(resRef.Reference, out var entry) == false)
                    throw new Exception($"Error referencing section resource '{resRef.Reference}'");
                //T item = new T(entry.Resource);
            }
        }

        protected T ReadSection<T>(ResourceBag resourceBag,
            Coding code)
            where T : IBaseBase
        {
            throw new NotImplementedException();
        }

        protected void WriteSection<T>(String title, Coding code, Int32 min, Int32 max, T item)
            where T : IBaseBase
        {
            throw new NotImplementedException();
        }

        protected void WriteSection<T>(String title, Coding code, Int32 min, Int32 max, List<T> items)
            where T : IBaseBase
        {
            throw new NotImplementedException();
        }
    }
}
