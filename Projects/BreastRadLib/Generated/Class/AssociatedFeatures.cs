using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class AssociatedFeatures : BreastRadBase, IObservationSectionFragment
	{
		//+ Fields
		
        public HasMemberList<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}
        public HasMemberList<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}
        public HasMemberList<IObservedFeature> ObservedFeature {get;}
		//- Fields

		public AssociatedFeatures()
		{
			//+ Constructor
		
            this.MGAbnormalityArchitecturalDistortion = new HasMemberList<IMGAbnormalityArchitecturalDistortion>(0, -1);
            this.MGAbnormalityCalcification = new HasMemberList<IMGAbnormalityCalcification>(0, -1);
            this.ObservedFeature = new HasMemberList<IObservedFeature>(0, -1);
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
