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
		HasMemberList<IAbnormalityCyst> AbnormalityCyst {get;}                                                                                    // CSBuilder.cs:265
		HasMemberList<IAbnormalityDuct> AbnormalityDuct {get;}                                                                                    // CSBuilder.cs:265
		HasMemberList<IAbnormalityForeignObject> AbnormalityForeignObject {get;}                                                                  // CSBuilder.cs:265
		HasMemberList<IAbnormalityLymphNode> AbnormalityLymphNode {get;}                                                                          // CSBuilder.cs:265
		HasMemberList<IMass> Mass {get;}                                                                                                          // CSBuilder.cs:265
		HasMemberList<IAssociatedFeatures> AssociatedFeatures {get;}                                                                              // CSBuilder.cs:265
		HasMemberList<IAbnormalityFibroadenoma> AbnormalityFibroadenoma {get;}                                                                    // CSBuilder.cs:265
		HasMemberList<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}                                          // CSBuilder.cs:265
		HasMemberList<IMGAbnormalityAsymmetry> MGAbnormalityAsymmetry {get;}                                                                      // CSBuilder.cs:265
		HasMemberList<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}                                                              // CSBuilder.cs:265
		HasMemberList<IMGAbnormalityDensity> MGAbnormalityDensity {get;}                                                                          // CSBuilder.cs:265
		HasMemberList<IMGAbnormalityFatNecrosis> MGAbnormalityFatNecrosis {get;}                                                                  // CSBuilder.cs:265
		HasMemberList<IMGBreastDensity> MGBreastDensity {get;}                                                                                    // CSBuilder.cs:265
		//- Fields
	}
}
