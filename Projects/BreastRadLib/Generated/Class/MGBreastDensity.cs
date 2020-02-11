using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class MGBreastDensity : ObservationBase, IObservationLeafFragment, IBreastRadObservationNoComponentFragment, IBreastRadObservationNoDeviceFragment
	{
		//+ Fields
		//- Fields

		public MGBreastDensity(Observation resource) : base(resource)
		{
			//+ Constructor
			//- Constructor
		}

		public void Write()
		{
		//+ WriteCode
		//- WriteCode
		}

		public void Read(ResourceBag resourceBag)
		{
		//+ ReadCode
		//- ReadCode
		}

		//+ Methods
		//- Methods
	}
}
