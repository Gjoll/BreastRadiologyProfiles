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
	public class AssociatedFeatures : BreastRadBase, IAssociatedFeatures                                                                       // CSBuilder.cs:218
	//- Header
	{
		//+ Fields
		public List<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;} = new List<IMGAbnormalityArchitecturalDistortion>();// CSBuilder.cs:166
		public List<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;} = new List<IMGAbnormalityCalcification>();                     // CSBuilder.cs:166
		public List<IObservedFeature> ObservedFeature {get;} = new List<IObservedFeature>();                                                      // CSBuilder.cs:166
		//- Fields
	}
}
