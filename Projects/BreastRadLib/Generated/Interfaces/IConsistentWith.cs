using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public interface IConsistentWith : IObservationBase, IObservationLeafFragment, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, IBreastRadObservationNoComponentFragment
	{
		//+ Fields
		//- Fields

		//+ Methods
		//- Methods
	}
}
