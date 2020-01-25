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
	public class MGAbnormalityArchitecturalDistortion : BreastRadBase, IMGAbnormalityArchitecturalDistortion                                   // CSBuilder.cs:262
	//- Header
	{
		//+ Fields
		public List<IAssociatedFeatures> AssociatedFeatures {get;} = new List<IAssociatedFeatures>();                                             // CSBuilder.cs:210
		public List<IConsistentWith> ConsistentWith {get;} = new List<IConsistentWith>();                                                         // CSBuilder.cs:210
		//- Fields
	}
}
