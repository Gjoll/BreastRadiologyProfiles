using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface ICompositionBase : IResourceBase
    {
    }

    public class CompositionBase : ResourceBase, ICompositionBase
    {
        public Composition Resource => (Composition)this.resource;

        public CompositionBase(Composition resource) : base(resource)
        {
        }

        protected void ClearSection()
        {
            this.Resource.Section.Clear();
        }

        protected void ReadSection<T>(ResourceBag resourceBag,
            Coding code, 
            Int32 min, 
            Int32 max, 
            List<T> items)
            where T : IBaseBase
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

            items.Clear();
            foreach (Composition.SectionComponent section in this.Resource.Section)
            {
                if (IsCode(section.Code))
                {
                }
            }
            throw new NotImplementedException();
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
