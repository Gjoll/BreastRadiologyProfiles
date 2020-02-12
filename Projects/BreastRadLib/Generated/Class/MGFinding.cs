using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class MGFinding : ObservationBase, IObservationSectionFragment
	{
		//+ Fields
		
        public MemberList<IAbnormalityCyst> AbnormalityCyst {get;}
        public MemberList<IAbnormalityDuct> AbnormalityDuct {get;}
        public MemberList<IAbnormalityForeignObject> AbnormalityForeignObject {get;}
        public MemberList<IAbnormalityLymphNode> AbnormalityLymphNode {get;}
        public MemberList<IAbnormalityMass> AbnormalityMass {get;}
        public MemberList<IAssociatedFeatures> AssociatedFeatures {get;}
        public MemberList<IAbnormalityFibroadenoma> AbnormalityFibroadenoma {get;}
        public MemberList<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}
        public MemberList<IMGAbnormalityAsymmetry> MGAbnormalityAsymmetry {get;}
        public MemberList<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}
        public MemberList<IMGAbnormalityDensity> MGAbnormalityDensity {get;}
        public MemberList<IMGAbnormalityFatNecrosis> MGAbnormalityFatNecrosis {get;}
        public MemberList<IMGBreastDensity> MGBreastDensity {get;}
		//- Fields

		public MGFinding(Observation resource) : this()
		{
			this.SetResource(resource);
		}

		public MGFinding() : base()
		{
			//+ Constructor
		
            this.AbnormalityCyst = CreateHasMemberList<IAbnormalityCyst>(0, -1);
            this.AbnormalityDuct = CreateHasMemberList<IAbnormalityDuct>(0, -1);
            this.AbnormalityForeignObject = CreateHasMemberList<IAbnormalityForeignObject>(0, -1);
            this.AbnormalityLymphNode = CreateHasMemberList<IAbnormalityLymphNode>(0, -1);
            this.AbnormalityMass = CreateHasMemberList<IAbnormalityMass>(0, -1);
            this.AssociatedFeatures = CreateHasMemberList<IAssociatedFeatures>(0, -1);
            this.AbnormalityFibroadenoma = CreateHasMemberList<IAbnormalityFibroadenoma>(0, -1);
            this.MGAbnormalityArchitecturalDistortion = CreateHasMemberList<IMGAbnormalityArchitecturalDistortion>(0, -1);
            this.MGAbnormalityAsymmetry = CreateHasMemberList<IMGAbnormalityAsymmetry>(0, -1);
            this.MGAbnormalityCalcification = CreateHasMemberList<IMGAbnormalityCalcification>(0, -1);
            this.MGAbnormalityDensity = CreateHasMemberList<IMGAbnormalityDensity>(0, -1);
            this.MGAbnormalityFatNecrosis = CreateHasMemberList<IMGAbnormalityFatNecrosis>(0, -1);
            this.MGBreastDensity = CreateHasMemberList<IMGBreastDensity>(1, 1);
			//- Constructor
		}

		public void Write()
		{
		//+ WriteCode
		//- WriteCode
		}

		public void Read(ResourceBag resourceBag)
		{
		//+ ReadCode
		//- ReadCode
		}

		//+ Methods
		/// <summary>
		/// Bind fhir resource to this
		/// </summary>
		public override void SetResource(Base resource)                                                                                           // CSDefineBase.cs:113
		{                                                                                                                                         // CSDefineBase.cs:114
		    Observation r = resource as Observation;                                                                                              // CSDefineBase.cs:115
		    if (r == null)                                                                                                                        // CSDefineBase.cs:116
		        throw new Exception("resource must be of type Observation");                                                                      // CSDefineBase.cs:117
		    this.resource = r;                                                                                                                    // CSDefineBase.cs:118
		    SetProfileUrl("http://hl7.org/fhir/us/breast-radiology/StructureDefinition/MGFinding");                                               // CSDefineBase.cs:119
		}                                                                                                                                         // CSDefineBase.cs:120
		//- Methods
	}
}
