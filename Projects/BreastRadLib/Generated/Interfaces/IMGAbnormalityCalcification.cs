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
	public interface IMGAbnormalityCalcification  : IObservationLeafFragment, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, ICommonComponentsFragment, INotPreviouslySeenComponentFragment, IObservedCountFragment, ICorrespondsWithFragment// CSBuilder.cs:210
	//- Header
	{
		//+ Fields
		List<IAssociatedFeatures> AssociatedFeatures {get;}                                                                                       // CSBuilder.cs:173
		List<IConsistentWith> ConsistentWith {get;}                                                                                               // CSBuilder.cs:173
		//- Fields
	}
}
