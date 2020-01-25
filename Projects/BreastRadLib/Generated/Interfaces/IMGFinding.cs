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
	public interface IMGFinding  : IObservationSectionFragment                                                                                 // CSBuilder.cs:210
	//- Header
	{
		//+ Fields
		List<IAbnormalityCyst> AbnormalityCyst {get;}                                                                                             // CSBuilder.cs:173
		List<IAbnormalityDuct> AbnormalityDuct {get;}                                                                                             // CSBuilder.cs:173
		List<IAbnormalityForeignObject> AbnormalityForeignObject {get;}                                                                           // CSBuilder.cs:173
		List<IAbnormalityLymphNode> AbnormalityLymphNode {get;}                                                                                   // CSBuilder.cs:173
		List<IMass> Mass {get;}                                                                                                                   // CSBuilder.cs:173
		List<IAssociatedFeatures> AssociatedFeatures {get;}                                                                                       // CSBuilder.cs:173
		List<IAbnormalityFibroadenoma> AbnormalityFibroadenoma {get;}                                                                             // CSBuilder.cs:173
		List<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}                                                   // CSBuilder.cs:173
		List<IMGAbnormalityAsymmetry> MGAbnormalityAsymmetry {get;}                                                                               // CSBuilder.cs:173
		List<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}                                                                       // CSBuilder.cs:173
		List<IMGAbnormalityDensity> MGAbnormalityDensity {get;}                                                                                   // CSBuilder.cs:173
		List<IMGAbnormalityFatNecrosis> MGAbnormalityFatNecrosis {get;}                                                                           // CSBuilder.cs:173
		List<IMGBreastDensity> MGBreastDensity {get;}                                                                                             // CSBuilder.cs:173
		//- Fields
	}
}
