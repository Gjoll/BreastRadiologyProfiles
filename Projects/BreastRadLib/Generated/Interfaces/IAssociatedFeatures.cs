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
	public interface IAssociatedFeatures  : IObservationSectionFragment                                                                        // CSBuilder.cs:254
	//- Header
	{
		//+ Fields
		List<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}                                                   // CSBuilder.cs:217
		List<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}                                                                       // CSBuilder.cs:217
		List<IObservedFeature> ObservedFeature {get;}                                                                                             // CSBuilder.cs:217
		//- Fields
	}
}
