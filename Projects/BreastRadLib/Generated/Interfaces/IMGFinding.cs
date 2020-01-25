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
	public interface IMGFinding  : IObservationSectionFragment                                                                                 // CSBuilder.cs:254
	//- Header
	{
		//+ Fields
		List<IAbnormalityCyst> AbnormalityCyst {get;}                                                                                             // CSBuilder.cs:217
		List<IAbnormalityDuct> AbnormalityDuct {get;}                                                                                             // CSBuilder.cs:217
		List<IAbnormalityForeignObject> AbnormalityForeignObject {get;}                                                                           // CSBuilder.cs:217
		List<IAbnormalityLymphNode> AbnormalityLymphNode {get;}                                                                                   // CSBuilder.cs:217
		List<IMass> Mass {get;}                                                                                                                   // CSBuilder.cs:217
		List<IAssociatedFeatures> AssociatedFeatures {get;}                                                                                       // CSBuilder.cs:217
		List<IAbnormalityFibroadenoma> AbnormalityFibroadenoma {get;}                                                                             // CSBuilder.cs:217
		List<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}                                                   // CSBuilder.cs:217
		List<IMGAbnormalityAsymmetry> MGAbnormalityAsymmetry {get;}                                                                               // CSBuilder.cs:217
		List<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}                                                                       // CSBuilder.cs:217
		List<IMGAbnormalityDensity> MGAbnormalityDensity {get;}                                                                                   // CSBuilder.cs:217
		List<IMGAbnormalityFatNecrosis> MGAbnormalityFatNecrosis {get;}                                                                           // CSBuilder.cs:217
		List<IMGBreastDensity> MGBreastDensity {get;}                                                                                             // CSBuilder.cs:217
		//- Fields
	}
}
