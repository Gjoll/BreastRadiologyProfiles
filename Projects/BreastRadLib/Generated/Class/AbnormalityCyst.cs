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
	public class AbnormalityCyst : BreastRadBase, IAbnormalityCyst
	//- Header
	{
		//+ Fields
		public List<IAssociatedFeatures> AssociatedFeatures {get;} = new List<IAssociatedFeatures>();
		public List<IConsistentWith> ConsistentWith {get;} = new List<IConsistentWith>();
		//- Fields
	}
}
