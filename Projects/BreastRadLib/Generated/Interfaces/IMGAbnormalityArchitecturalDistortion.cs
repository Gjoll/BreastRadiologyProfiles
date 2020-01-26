using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public interface IMGAbnormalityArchitecturalDistortion : IBreastRad, IObservationLeafFragment, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, ICommonComponentsFragment, IShapeComponentsFragment, INotPreviouslySeenComponentFragment, ICorrespondsWithFragment
	{
		//+ Fields
		HasMemberList<IAssociatedFeatures> AssociatedFeatures {get;}                                                                              // CSBuilder.cs:265
		HasMemberList<IConsistentWith> ConsistentWith {get;}                                                                                      // CSBuilder.cs:265
		//- Fields
	}
}
