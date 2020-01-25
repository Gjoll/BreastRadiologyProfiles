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
	public interface IAbnormalityForeignObject  : IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, ICommonComponentsFragment, INotPreviouslySeenComponentFragment, ICorrespondsWithFragment, IBiRadFragment// CSBuilder.cs:254
	//- Header
	{
		//+ Fields
		List<IConsistentWith> ConsistentWith {get;}                                                                                               // CSBuilder.cs:217
		List<IAssociatedFeatures> AssociatedFeatures {get;}                                                                                       // CSBuilder.cs:217
		//- Fields
	}
}
