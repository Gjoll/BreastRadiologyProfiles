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
	public interface IMGFinding  : IObservationSectionFragment
	//- Header
	{
		//+ Fields
		List<IAbnormalityCyst> AbnormalityCyst {get;}
		List<IAbnormalityDuct> AbnormalityDuct {get;}
		List<IAbnormalityForeignObject> AbnormalityForeignObject {get;}
		List<IAbnormalityLymphNode> AbnormalityLymphNode {get;}
		List<IMass> Mass {get;}
		List<IAssociatedFeatures> AssociatedFeatures {get;}
		List<IAbnormalityFibroadenoma> AbnormalityFibroadenoma {get;}
		List<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}
		List<IMGAbnormalityAsymmetry> MGAbnormalityAsymmetry {get;}
		List<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}
		List<IMGAbnormalityDensity> MGAbnormalityDensity {get;}
		List<IMGAbnormalityFatNecrosis> MGAbnormalityFatNecrosis {get;}
		List<IMGBreastDensity> MGBreastDensity {get;}
		//- Fields
	}
}
