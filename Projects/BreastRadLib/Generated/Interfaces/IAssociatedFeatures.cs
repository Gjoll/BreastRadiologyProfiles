using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public interface IAssociatedFeatures : IBreastRad, IObservationSectionFragment
	{
		//+ Fields
		HasMemberList<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}                                          // CSBuilder.cs:265
		HasMemberList<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}                                                              // CSBuilder.cs:265
		HasMemberList<IObservedFeature> ObservedFeature {get;}                                                                                    // CSBuilder.cs:265
		//- Fields
	}
}
