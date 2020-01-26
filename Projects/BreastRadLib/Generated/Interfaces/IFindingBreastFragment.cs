using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public interface IFindingBreastFragment : IBreastRad, IHeaderFragment, IBreastRadObservationNoDeviceFragment, IServiceRecommendationFragment
	{
		//+ Fields
		HasMemberList<IMGFinding> MGFinding {get;}                                                                                                // CSBuilder.cs:265
		HasMemberList<IMRIFinding> MRIFinding {get;}                                                                                              // CSBuilder.cs:265
		HasMemberList<INMFinding> NMFinding {get;}                                                                                                // CSBuilder.cs:265
		HasMemberList<IUSFinding> USFinding {get;}                                                                                                // CSBuilder.cs:265
		//- Fields
	}
}
