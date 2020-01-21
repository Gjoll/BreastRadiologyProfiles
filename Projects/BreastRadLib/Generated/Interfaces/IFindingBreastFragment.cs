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
	public interface IFindingBreastFragment  : IHeaderFragment, IBreastRadObservationNoDeviceFragment
	//- Header
	{
		//+ Fields
		List<IMGFinding> MGFinding {get;}
		List<IMRIFinding> MRIFinding {get;}
		List<INMFinding> NMFinding {get;}
		List<IUSFinding> USFinding {get;}
		//- Fields
	}
}
