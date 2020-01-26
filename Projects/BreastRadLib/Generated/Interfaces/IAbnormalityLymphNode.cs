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
	public interface IAbnormalityLymphNode  : IObservationLeafFragment, ITumorSatelliteFragment, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, ICommonComponentsFragment, IShapeComponentsFragment, IObservedCountFragment, INotPreviouslySeenComponentFragment, ICorrespondsWithFragment// CSBuilder.cs:304
	//- Header
	{
		//+ Fields
		HasMemberList<IAssociatedFeatures> AssociatedFeatures {get;}                                                                              // CSBuilder.cs:263
		//- Fields
	}
}
