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
		
        HasMemberList<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}
        HasMemberList<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}
        HasMemberList<IObservedFeature> ObservedFeature {get;}
		//- Fields
	}
}
