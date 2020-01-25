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
	public class AbnormalityFibroadenoma : BreastRadBase, IAbnormalityFibroadenoma                                                             // CSBuilder.cs:218
	//- Header
	{
		//+ Fields
		public List<IAssociatedFeatures> AssociatedFeatures {get;} = new List<IAssociatedFeatures>();                                             // CSBuilder.cs:166
		//- Fields
	}
}
