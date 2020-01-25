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
	public class AbnormalityDuct : BreastRadBase, IAbnormalityDuct                                                                             // CSBuilder.cs:218
	//- Header
	{
		//+ Fields
		public List<IConsistentWith> ConsistentWith {get;} = new List<IConsistentWith>();                                                         // CSBuilder.cs:166
		//- Fields
	}
}
