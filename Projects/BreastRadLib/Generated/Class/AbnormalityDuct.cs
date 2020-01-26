using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class AbnormalityDuct : BreastRadBase, IObservationLeafFragment, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, ICommonComponentsFragment, IShapeComponentsFragment, IObservedCountFragment, INotPreviouslySeenComponentFragment, ICorrespondsWithFragment
	{
		//+ Fields
		
        public HasMemberList<IConsistentWith> ConsistentWith {get;}
		//- Fields

		public AbnormalityDuct()
		{
			//+ Constructor
		
            this.ConsistentWith = new HasMemberList<IConsistentWith>(0, -1);
			//- Constructor
		}

		public void Load(ResourceBag resourceBag, Observation resource)
		{
		    LoadHasMembers(resourceBag, resource);
		}

		public void Unload(ResourceBag resourceBag, Observation resource)
		{
		    UnloadHasMembers(resourceBag, resource);
		}

		//+ HasMembers
		public void LoadHasMembers(ResourceBag resourceBag, Observation resource)
		{
		    foreach (ResourceReference hasMember in resource.HasMember)
		    {
		        //if (resourceBag.TryGetEntry(hasMember.Url, out Bundle.EntryComponent entry) == false)
		        //    throw new Exception("Reference '{hasMember.Url}' not found in bag");
		    }
		}

		public void UnloadHasMembers(ResourceBag resourceBag, Observation resource)
		{
		}
		//- HasMembers
	}
}
