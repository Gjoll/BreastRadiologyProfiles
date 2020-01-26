using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public interface IMGFinding : IBreastRad, IObservationSectionFragment
	{
		//+ Fields
		
        HasMemberList<IAbnormalityCyst> AbnormalityCyst {get;}
        HasMemberList<IAbnormalityDuct> AbnormalityDuct {get;}
        HasMemberList<IAbnormalityForeignObject> AbnormalityForeignObject {get;}
        HasMemberList<IAbnormalityLymphNode> AbnormalityLymphNode {get;}
        HasMemberList<IMass> Mass {get;}
        HasMemberList<IAssociatedFeatures> AssociatedFeatures {get;}
        HasMemberList<IAbnormalityFibroadenoma> AbnormalityFibroadenoma {get;}
        HasMemberList<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}
        HasMemberList<IMGAbnormalityAsymmetry> MGAbnormalityAsymmetry {get;}
        HasMemberList<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}
        HasMemberList<IMGAbnormalityDensity> MGAbnormalityDensity {get;}
        HasMemberList<IMGAbnormalityFatNecrosis> MGAbnormalityFatNecrosis {get;}
        HasMemberList<IMGBreastDensity> MGBreastDensity {get;}
		//- Fields
	}
}
