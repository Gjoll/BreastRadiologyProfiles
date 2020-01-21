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
	public interface IAssociatedFeatures  : IObservationSectionFragment
	//- Header
	{
		//+ Fields
		List<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}
		List<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}
		List<IObservedFeature> ObservedFeature {get;}
		//- Fields
	}
}
