using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public interface IMGAbnormalityCalcification : IBreastRad, IObservationLeafFragment, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, ICommonComponentsFragment, INotPreviouslySeenComponentFragment, IObservedCountFragment, ICorrespondsWithFragment
	{
		//+ Fields
		
        HasMemberList<IAssociatedFeatures> AssociatedFeatures {get;}
        HasMemberList<IConsistentWith> ConsistentWith {get;}
		//- Fields
	}
}
