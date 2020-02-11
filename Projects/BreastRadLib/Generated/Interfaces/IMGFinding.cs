using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public interface IMGFinding : IObservationBase, IObservationSectionFragment
	{
		//+ Fields
		
        MemberList<IAbnormalityCyst> AbnormalityCyst {get;}
        MemberList<IAbnormalityDuct> AbnormalityDuct {get;}
        MemberList<IAbnormalityForeignObject> AbnormalityForeignObject {get;}
        MemberList<IAbnormalityLymphNode> AbnormalityLymphNode {get;}
        MemberList<IAbnormalityMass> AbnormalityMass {get;}
        MemberList<IAssociatedFeatures> AssociatedFeatures {get;}
        MemberList<IAbnormalityFibroadenoma> AbnormalityFibroadenoma {get;}
        MemberList<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}
        MemberList<IMGAbnormalityAsymmetry> MGAbnormalityAsymmetry {get;}
        MemberList<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}
        MemberList<IMGAbnormalityDensity> MGAbnormalityDensity {get;}
        MemberList<IMGAbnormalityFatNecrosis> MGAbnormalityFatNecrosis {get;}
        MemberList<IMGBreastDensity> MGBreastDensity {get;}
		//- Fields

		//+ Methods
		//- Methods
	}
}
