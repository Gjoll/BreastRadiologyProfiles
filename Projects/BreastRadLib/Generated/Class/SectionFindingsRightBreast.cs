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
	public class SectionFindingsRightBreast : BreastRadBase, ISectionFindingsRightBreast                                                       // CSBuilder.cs:262
	//- Header
	{
		//+ Fields
		public List<IMGFinding> MGFinding {get;} = new List<IMGFinding>();                                                                        // CSBuilder.cs:210
		public List<IMRIFinding> MRIFinding {get;} = new List<IMRIFinding>();                                                                     // CSBuilder.cs:210
		public List<INMFinding> NMFinding {get;} = new List<INMFinding>();                                                                        // CSBuilder.cs:210
		public List<IUSFinding> USFinding {get;} = new List<IUSFinding>();                                                                        // CSBuilder.cs:210
		//- Fields
	}
}
