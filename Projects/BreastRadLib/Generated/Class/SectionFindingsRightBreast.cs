using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class SectionFindingsRightBreast : BreastRadBase, IFindingBreastFragment
	{
		//+ Fields
		
        public HasMemberList<IMGFinding> MGFinding {get;}
        public HasMemberList<IMRIFinding> MRIFinding {get;}
        public HasMemberList<INMFinding> NMFinding {get;}
        public HasMemberList<IUSFinding> USFinding {get;}
		//- Fields

		public SectionFindingsRightBreast()
		{
			//+ Constructor
		
            this.MGFinding = new HasMemberList<IMGFinding>(0, -1);
            this.MRIFinding = new HasMemberList<IMRIFinding>(0, -1);
            this.NMFinding = new HasMemberList<INMFinding>(0, -1);
            this.USFinding = new HasMemberList<IUSFinding>(0, -1);
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
