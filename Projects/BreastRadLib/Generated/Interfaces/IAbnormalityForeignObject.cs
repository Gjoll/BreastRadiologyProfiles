using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public interface IAbnormalityForeignObject : IBreastRad, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, ICommonComponentsFragment, INotPreviouslySeenComponentFragment, ICorrespondsWithFragment, IBiRadFragment
	{
		//+ Fields
		
        HasMemberList<IConsistentWith> ConsistentWith {get;}
        HasMemberList<IAssociatedFeatures> AssociatedFeatures {get;}
		//- Fields
	}
}
