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
	public class AbnormalityForeignObject : BreastRadBase, IAbnormalityForeignObject
	//- Header
	{
		//+ Fields
		public List<IConsistentWith> ConsistentWith {get;} = new List<IConsistentWith>();
		public List<IAssociatedFeatures> AssociatedFeatures {get;} = new List<IAssociatedFeatures>();
		//- Fields
	}
}
