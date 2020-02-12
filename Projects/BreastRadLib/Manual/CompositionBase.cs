using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            where T : ResourceBase
        {
            items.Clear();
            Composition.SectionComponent section = this.FindSection(code);
            if (section == null)
                return;
            foreach (ResourceReference resRef in section.Entry)
            {
                if (resourceBag.TryGetEntry(resRef.Reference, out var entry) == false)
                    throw new Exception($"Error referencing section resource '{resRef.Reference}'");
                Resource referencedResource = entry.Resource;
                if (referencedResource.Meta.Profile.Count() != 1)
                    throw new Exception($"Invalid Meta.profile. Expected 1, got {referencedResource.Meta.Profile.Count()}");
                String profile = referencedResource.Meta.Profile.First();
                T item = ResourceFactory.CreateBreastRadProfileResource(profile) as T;
                if (item == null)
                    throw new Exception($"Error creating resource of profile {profile}");
            }
        }

        /// <summary>
        /// Set the fhir resource to the indicated value.
        /// </summary>
        /// <param name="resource"></param>
        public override void SetResource(Base resource)
        {
            Composition r = resource as Composition;
            if (r == null)
                throw new Exception("resource must be of type Composition");
            this.resource = r;
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
