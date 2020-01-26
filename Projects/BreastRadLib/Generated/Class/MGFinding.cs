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
		
        public HasMemberList<IAbnormalityCyst> AbnormalityCyst {get;}
        public HasMemberList<IAbnormalityDuct> AbnormalityDuct {get;}
        public HasMemberList<IAbnormalityForeignObject> AbnormalityForeignObject {get;}
        public HasMemberList<IAbnormalityLymphNode> AbnormalityLymphNode {get;}
        public HasMemberList<IMass> Mass {get;}
        public HasMemberList<IAssociatedFeatures> AssociatedFeatures {get;}
        public HasMemberList<IAbnormalityFibroadenoma> AbnormalityFibroadenoma {get;}
        public HasMemberList<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}
        public HasMemberList<IMGAbnormalityAsymmetry> MGAbnormalityAsymmetry {get;}
        public HasMemberList<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}
        public HasMemberList<IMGAbnormalityDensity> MGAbnormalityDensity {get;}
        public HasMemberList<IMGAbnormalityFatNecrosis> MGAbnormalityFatNecrosis {get;}
        public HasMemberList<IMGBreastDensity> MGBreastDensity {get;}
		//- Fields

		public MGFinding()
		{
			//+ Constructor
		
            this.AbnormalityCyst = new HasMemberList<IAbnormalityCyst>(0, -1);
            this.AbnormalityDuct = new HasMemberList<IAbnormalityDuct>(0, -1);
            this.AbnormalityForeignObject = new HasMemberList<IAbnormalityForeignObject>(0, -1);
            this.AbnormalityLymphNode = new HasMemberList<IAbnormalityLymphNode>(0, -1);
            this.Mass = new HasMemberList<IMass>(0, -1);
            this.AssociatedFeatures = new HasMemberList<IAssociatedFeatures>(0, -1);
            this.AbnormalityFibroadenoma = new HasMemberList<IAbnormalityFibroadenoma>(0, -1);
            this.MGAbnormalityArchitecturalDistortion = new HasMemberList<IMGAbnormalityArchitecturalDistortion>(0, -1);
            this.MGAbnormalityAsymmetry = new HasMemberList<IMGAbnormalityAsymmetry>(0, -1);
            this.MGAbnormalityCalcification = new HasMemberList<IMGAbnormalityCalcification>(0, -1);
            this.MGAbnormalityDensity = new HasMemberList<IMGAbnormalityDensity>(0, -1);
            this.MGAbnormalityFatNecrosis = new HasMemberList<IMGAbnormalityFatNecrosis>(0, -1);
            this.MGBreastDensity = new HasMemberList<IMGBreastDensity>(1, 1);
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
