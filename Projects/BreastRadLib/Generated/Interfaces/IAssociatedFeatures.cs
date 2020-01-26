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
	public interface IAssociatedFeatures  : IObservationSectionFragment                                                                        // CSBuilder.cs:304
	//- Header
	{
		//+ Fields
		HasMemberList<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}                                          // CSBuilder.cs:263
		HasMemberList<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}                                                              // CSBuilder.cs:263
		HasMemberList<IObservedFeature> ObservedFeature {get;}                                                                                    // CSBuilder.cs:263
		//- Fields
	}
}
