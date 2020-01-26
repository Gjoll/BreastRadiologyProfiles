using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	//+ Header
	public class SectionFindingsLeftBreast : BreastRadBase, ISectionFindingsLeftBreast                                                         // CSBuilder.cs:312
	//- Header
	{
		//+ Fields
		public HasMemberList<IMGFinding> MGFinding {get;}                                                                                         // CSBuilder.cs:220
		public HasMemberList<IMRIFinding> MRIFinding {get;}                                                                                       // CSBuilder.cs:220
		public HasMemberList<INMFinding> NMFinding {get;}                                                                                         // CSBuilder.cs:220
		public HasMemberList<IUSFinding> USFinding {get;}                                                                                         // CSBuilder.cs:220
		//- Fields

		//+ Constructor
		public SectionFindingsLeftBreast()                                                                                                        // CSBuilder.cs:318
		{                                                                                                                                         // CSBuilder.cs:319
		    this.MGFinding = new HasMemberList<IMGFinding>(0, -1);                                                                                // CSBuilder.cs:234
		    this.MRIFinding = new HasMemberList<IMRIFinding>(0, -1);                                                                              // CSBuilder.cs:234
		    this.NMFinding = new HasMemberList<INMFinding>(0, -1);                                                                                // CSBuilder.cs:234
		    this.USFinding = new HasMemberList<IUSFinding>(0, -1);                                                                                // CSBuilder.cs:234
		}                                                                                                                                         // CSBuilder.cs:321
		//- Constructor

		//+ Methods
		public void Load(ResourceBag resourceBag, Observation resource)                                                                           // CSBuilder.cs:328
		{                                                                                                                                         // CSBuilder.cs:329
		    LoadHasMembers(resourceBag, resource);                                                                                                // CSBuilder.cs:240
		}                                                                                                                                         // CSBuilder.cs:331
		                                                                                                                                          // CSBuilder.cs:332
		public void Unload(ResourceBag resourceBag, Observation resource)                                                                         // CSBuilder.cs:333
		{                                                                                                                                         // CSBuilder.cs:334
		}                                                                                                                                         // CSBuilder.cs:336
		                                                                                                                                          // CSBuilder.cs:244
		public void LoadHasMembers(ResourceBag resourceBag, Observation resource)                                                                 // CSBuilder.cs:245
		{                                                                                                                                         // CSBuilder.cs:246
		    foreach (ResourceReference hasMember in resource.HasMember)                                                                           // CSBuilder.cs:247
		    {                                                                                                                                     // CSBuilder.cs:248
		        if (resourceBag.TryGetEntry(hasMember.Url, out Bundle.EntryComponent entry) == false)                                             // CSBuilder.cs:249
		            throw new Exception("Reference '{hasMember.Url}' not found in bag");                                                          // CSBuilder.cs:250
		    }                                                                                                                                     // CSBuilder.cs:253
		}                                                                                                                                         // CSBuilder.cs:254
		//- Methods
	}
}
