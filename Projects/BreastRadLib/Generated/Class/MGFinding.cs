using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class MGFinding : BreastRadBase, IObservationSectionFragment
	{
		//+ Fields
		public HasMemberList<IAbnormalityCyst> AbnormalityCyst {get;}                                                                             // CSBuilder.cs:222
		public HasMemberList<IAbnormalityDuct> AbnormalityDuct {get;}                                                                             // CSBuilder.cs:222
		public HasMemberList<IAbnormalityForeignObject> AbnormalityForeignObject {get;}                                                           // CSBuilder.cs:222
		public HasMemberList<IAbnormalityLymphNode> AbnormalityLymphNode {get;}                                                                   // CSBuilder.cs:222
		public HasMemberList<IMass> Mass {get;}                                                                                                   // CSBuilder.cs:222
		public HasMemberList<IAssociatedFeatures> AssociatedFeatures {get;}                                                                       // CSBuilder.cs:222
		public HasMemberList<IAbnormalityFibroadenoma> AbnormalityFibroadenoma {get;}                                                             // CSBuilder.cs:222
		public HasMemberList<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}                                   // CSBuilder.cs:222
		public HasMemberList<IMGAbnormalityAsymmetry> MGAbnormalityAsymmetry {get;}                                                               // CSBuilder.cs:222
		public HasMemberList<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}                                                       // CSBuilder.cs:222
		public HasMemberList<IMGAbnormalityDensity> MGAbnormalityDensity {get;}                                                                   // CSBuilder.cs:222
		public HasMemberList<IMGAbnormalityFatNecrosis> MGAbnormalityFatNecrosis {get;}                                                           // CSBuilder.cs:222
		public HasMemberList<IMGBreastDensity> MGBreastDensity {get;}                                                                             // CSBuilder.cs:222
		//- Fields

		//+ Constructor
		public MGFinding()                                                                                                                        // CSBuilder.cs:308
		{                                                                                                                                         // CSBuilder.cs:309
		    this.AbnormalityCyst = new HasMemberList<IAbnormalityCyst>(0, -1);                                                                    // CSBuilder.cs:236
		    this.AbnormalityDuct = new HasMemberList<IAbnormalityDuct>(0, -1);                                                                    // CSBuilder.cs:236
		    this.AbnormalityForeignObject = new HasMemberList<IAbnormalityForeignObject>(0, -1);                                                  // CSBuilder.cs:236
		    this.AbnormalityLymphNode = new HasMemberList<IAbnormalityLymphNode>(0, -1);                                                          // CSBuilder.cs:236
		    this.Mass = new HasMemberList<IMass>(0, -1);                                                                                          // CSBuilder.cs:236
		    this.AssociatedFeatures = new HasMemberList<IAssociatedFeatures>(0, -1);                                                              // CSBuilder.cs:236
		    this.AbnormalityFibroadenoma = new HasMemberList<IAbnormalityFibroadenoma>(0, -1);                                                    // CSBuilder.cs:236
		    this.MGAbnormalityArchitecturalDistortion = new HasMemberList<IMGAbnormalityArchitecturalDistortion>(0, -1);                          // CSBuilder.cs:236
		    this.MGAbnormalityAsymmetry = new HasMemberList<IMGAbnormalityAsymmetry>(0, -1);                                                      // CSBuilder.cs:236
		    this.MGAbnormalityCalcification = new HasMemberList<IMGAbnormalityCalcification>(0, -1);                                              // CSBuilder.cs:236
		    this.MGAbnormalityDensity = new HasMemberList<IMGAbnormalityDensity>(0, -1);                                                          // CSBuilder.cs:236
		    this.MGAbnormalityFatNecrosis = new HasMemberList<IMGAbnormalityFatNecrosis>(0, -1);                                                  // CSBuilder.cs:236
		    this.MGBreastDensity = new HasMemberList<IMGBreastDensity>(1, 1);                                                                     // CSBuilder.cs:236
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
