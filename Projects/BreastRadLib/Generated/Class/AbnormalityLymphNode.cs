using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class AbnormalityLymphNode : BreastRadBase, IObservationLeafFragment, ITumorSatelliteFragment, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, ICommonComponentsFragment, IShapeComponentsFragment, IObservedCountFragment, INotPreviouslySeenComponentFragment, ICorrespondsWithFragment
	{
		//+ Fields
		public HasMemberList<IAssociatedFeatures> AssociatedFeatures {get;}                                                                       // CSBuilder.cs:222
		//- Fields

		//+ Constructor
		public AbnormalityLymphNode()                                                                                                             // CSBuilder.cs:308
		{                                                                                                                                         // CSBuilder.cs:309
		    this.AssociatedFeatures = new HasMemberList<IAssociatedFeatures>(0, 1);                                                               // CSBuilder.cs:236
		}                                                                                                                                         // CSBuilder.cs:311
		//- Constructor

		//+ Methods
		public void Load(ResourceBag resourceBag, Observation resource)                                                                           // CSBuilder.cs:318
		{                                                                                                                                         // CSBuilder.cs:319
		    LoadHasMembers(resourceBag, resource);                                                                                                // CSBuilder.cs:242
		}                                                                                                                                         // CSBuilder.cs:321
		                                                                                                                                          // CSBuilder.cs:322
		public void Unload(ResourceBag resourceBag, Observation resource)                                                                         // CSBuilder.cs:323
		{                                                                                                                                         // CSBuilder.cs:324
		}                                                                                                                                         // CSBuilder.cs:326
		                                                                                                                                          // CSBuilder.cs:246
		public void LoadHasMembers(ResourceBag resourceBag, Observation resource)                                                                 // CSBuilder.cs:247
		{                                                                                                                                         // CSBuilder.cs:248
		    foreach (ResourceReference hasMember in resource.HasMember)                                                                           // CSBuilder.cs:249
		    {                                                                                                                                     // CSBuilder.cs:250
		        //if (resourceBag.TryGetEntry(hasMember.Url, out Bundle.EntryComponent entry) == false)                                           // CSBuilder.cs:251
		        //    throw new Exception("Reference '{hasMember.Url}' not found in bag");                                                        // CSBuilder.cs:252
		    }                                                                                                                                     // CSBuilder.cs:255
		}                                                                                                                                         // CSBuilder.cs:256
		//- Methods
	}
}
