using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public interface IMGAbnormalityDensity : IBreastRad, IObservationLeafFragment, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, ICommonComponentsFragment, IShapeComponentsFragment, INotPreviouslySeenComponentFragment, IObservedCountFragment, ICorrespondsWithFragment
	{
		//+ Fields
		
        HasMemberList<IAssociatedFeatures> AssociatedFeatures {get;}
        HasMemberList<IConsistentWith> ConsistentWith {get;}
		//- Fields
	}
}
