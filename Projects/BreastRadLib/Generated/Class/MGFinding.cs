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
	public class MGFinding : BreastRadBase, IMGFinding                                                                                         // CSBuilder.cs:312
	//- Header
	{
		//+ Fields
		public HasMemberList<IAbnormalityCyst> AbnormalityCyst {get;}                                                                             // CSBuilder.cs:220
		public HasMemberList<IAbnormalityDuct> AbnormalityDuct {get;}                                                                             // CSBuilder.cs:220
		public HasMemberList<IAbnormalityForeignObject> AbnormalityForeignObject {get;}                                                           // CSBuilder.cs:220
		public HasMemberList<IAbnormalityLymphNode> AbnormalityLymphNode {get;}                                                                   // CSBuilder.cs:220
		public HasMemberList<IMass> Mass {get;}                                                                                                   // CSBuilder.cs:220
		public HasMemberList<IAssociatedFeatures> AssociatedFeatures {get;}                                                                       // CSBuilder.cs:220
		public HasMemberList<IAbnormalityFibroadenoma> AbnormalityFibroadenoma {get;}                                                             // CSBuilder.cs:220
		public HasMemberList<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}                                   // CSBuilder.cs:220
		public HasMemberList<IMGAbnormalityAsymmetry> MGAbnormalityAsymmetry {get;}                                                               // CSBuilder.cs:220
		public HasMemberList<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}                                                       // CSBuilder.cs:220
		public HasMemberList<IMGAbnormalityDensity> MGAbnormalityDensity {get;}                                                                   // CSBuilder.cs:220
		public HasMemberList<IMGAbnormalityFatNecrosis> MGAbnormalityFatNecrosis {get;}                                                           // CSBuilder.cs:220
		public HasMemberList<IMGBreastDensity> MGBreastDensity {get;}                                                                             // CSBuilder.cs:220
		//- Fields

		//+ Constructor
		public MGFinding()                                                                                                                        // CSBuilder.cs:318
		{                                                                                                                                         // CSBuilder.cs:319
		    this.AbnormalityCyst = new HasMemberList<IAbnormalityCyst>(0, -1);                                                                    // CSBuilder.cs:234
		    this.AbnormalityDuct = new HasMemberList<IAbnormalityDuct>(0, -1);                                                                    // CSBuilder.cs:234
		    this.AbnormalityForeignObject = new HasMemberList<IAbnormalityForeignObject>(0, -1);                                                  // CSBuilder.cs:234
		    this.AbnormalityLymphNode = new HasMemberList<IAbnormalityLymphNode>(0, -1);                                                          // CSBuilder.cs:234
		    this.Mass = new HasMemberList<IMass>(0, -1);                                                                                          // CSBuilder.cs:234
		    this.AssociatedFeatures = new HasMemberList<IAssociatedFeatures>(0, -1);                                                              // CSBuilder.cs:234
		    this.AbnormalityFibroadenoma = new HasMemberList<IAbnormalityFibroadenoma>(0, -1);                                                    // CSBuilder.cs:234
		    this.MGAbnormalityArchitecturalDistortion = new HasMemberList<IMGAbnormalityArchitecturalDistortion>(0, -1);                          // CSBuilder.cs:234
		    this.MGAbnormalityAsymmetry = new HasMemberList<IMGAbnormalityAsymmetry>(0, -1);                                                      // CSBuilder.cs:234
		    this.MGAbnormalityCalcification = new HasMemberList<IMGAbnormalityCalcification>(0, -1);                                              // CSBuilder.cs:234
		    this.MGAbnormalityDensity = new HasMemberList<IMGAbnormalityDensity>(0, -1);                                                          // CSBuilder.cs:234
		    this.MGAbnormalityFatNecrosis = new HasMemberList<IMGAbnormalityFatNecrosis>(0, -1);                                                  // CSBuilder.cs:234
		    this.MGBreastDensity = new HasMemberList<IMGBreastDensity>(1, 1);                                                                     // CSBuilder.cs:234
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
