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
	public interface IMGFinding  : IObservationSectionFragment                                                                                 // CSBuilder.cs:304
	//- Header
	{
		//+ Fields
		HasMemberList<IAbnormalityCyst> AbnormalityCyst {get;}                                                                                    // CSBuilder.cs:263
		HasMemberList<IAbnormalityDuct> AbnormalityDuct {get;}                                                                                    // CSBuilder.cs:263
		HasMemberList<IAbnormalityForeignObject> AbnormalityForeignObject {get;}                                                                  // CSBuilder.cs:263
		HasMemberList<IAbnormalityLymphNode> AbnormalityLymphNode {get;}                                                                          // CSBuilder.cs:263
		HasMemberList<IMass> Mass {get;}                                                                                                          // CSBuilder.cs:263
		HasMemberList<IAssociatedFeatures> AssociatedFeatures {get;}                                                                              // CSBuilder.cs:263
		HasMemberList<IAbnormalityFibroadenoma> AbnormalityFibroadenoma {get;}                                                                    // CSBuilder.cs:263
		HasMemberList<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}                                          // CSBuilder.cs:263
		HasMemberList<IMGAbnormalityAsymmetry> MGAbnormalityAsymmetry {get;}                                                                      // CSBuilder.cs:263
		HasMemberList<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}                                                              // CSBuilder.cs:263
		HasMemberList<IMGAbnormalityDensity> MGAbnormalityDensity {get;}                                                                          // CSBuilder.cs:263
		HasMemberList<IMGAbnormalityFatNecrosis> MGAbnormalityFatNecrosis {get;}                                                                  // CSBuilder.cs:263
		HasMemberList<IMGBreastDensity> MGBreastDensity {get;}                                                                                    // CSBuilder.cs:263
		//- Fields
	}
}
