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
	public interface IFindingBreastFragment  : IHeaderFragment, IBreastRadObservationNoDeviceFragment, IServiceRecommendationFragment          // CSBuilder.cs:304
	//- Header
	{
		//+ Fields
		HasMemberList<IMGFinding> MGFinding {get;}                                                                                                // CSBuilder.cs:263
		HasMemberList<IMRIFinding> MRIFinding {get;}                                                                                              // CSBuilder.cs:263
		HasMemberList<INMFinding> NMFinding {get;}                                                                                                // CSBuilder.cs:263
		HasMemberList<IUSFinding> USFinding {get;}                                                                                                // CSBuilder.cs:263
		//- Fields
	}
}
