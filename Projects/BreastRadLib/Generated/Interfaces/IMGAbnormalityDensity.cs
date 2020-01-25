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
	public interface IMGAbnormalityDensity  : IObservationLeafFragment, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, ICommonComponentsFragment, IShapeComponentsFragment, INotPreviouslySeenComponentFragment, IObservedCountFragment, ICorrespondsWithFragment// CSBuilder.cs:254
	//- Header
	{
		//+ Fields
		List<IAssociatedFeatures> AssociatedFeatures {get;}                                                                                       // CSBuilder.cs:217
		List<IConsistentWith> ConsistentWith {get;}                                                                                               // CSBuilder.cs:217
		//- Fields
	}
}
