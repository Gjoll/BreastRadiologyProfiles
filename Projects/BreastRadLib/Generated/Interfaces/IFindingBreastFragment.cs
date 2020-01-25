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
	public interface IFindingBreastFragment  : IHeaderFragment, IBreastRadObservationNoDeviceFragment, IServiceRecommendationFragment          // CSBuilder.cs:210
	//- Header
	{
		//+ Fields
		List<IMGFinding> MGFinding {get;}                                                                                                         // CSBuilder.cs:173
		List<IMRIFinding> MRIFinding {get;}                                                                                                       // CSBuilder.cs:173
		List<INMFinding> NMFinding {get;}                                                                                                         // CSBuilder.cs:173
		List<IUSFinding> USFinding {get;}                                                                                                         // CSBuilder.cs:173
		//- Fields
	}
}
