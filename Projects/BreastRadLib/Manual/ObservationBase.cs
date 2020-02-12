using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public interface IObservationBase : IResourceBase
    {
    }

    public class ObservationBase: ResourceBase, IObservationBase
    {
        public Observation Resource => (Observation) this.resource;

        List<IMemberList> hasMemberLists = new List<IMemberList>();

        public ObservationBase(Observation resource) : base(resource)
        {
        }

        public ObservationBase() : base()
        {
        }

        public override void SetResource(Base r) => this.resource = (Observation)r;

        protected MemberList<T> CreateHasMemberList<T>(Int32 min, Int32 max)
            where T : IResourceBase
        {
            MemberList<T> retVal = new MemberList<T>(min, max);
            hasMemberLists.Add(retVal);
            return retVal;
        }

        public void LoadHasMembers(ResourceBag resourceBag)
        {
            //foreach (ResourceReference hasMember in resource.HasMember)
            //{
            //    //if (resourceBag.TryGetEntry(hasMember.Url, out Bundle.EntryComponent entry) == false)
            //    //    throw new Exception("Reference '{hasMember.Url}' not found in bag");
            //}
        }

        public void Unload(ResourceBag resourceBag)
        {
            UnloadHasMembers(resourceBag);
        }

        public void UnloadHasMembers(ResourceBag resourceBag)
        {
        }
    }
}
