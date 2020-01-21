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
	public class SectionFindingsLeftBreast : BreastRadBase, ISectionFindingsLeftBreast
	//- Header
	{
		//+ Fields
		public List<IMGFinding> MGFinding {get;} = new List<IMGFinding>();
		public List<IMRIFinding> MRIFinding {get;} = new List<IMRIFinding>();
		public List<INMFinding> NMFinding {get;} = new List<INMFinding>();
		public List<IUSFinding> USFinding {get;} = new List<IUSFinding>();
		//- Fields
	}
}
