using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class ServiceRecommendationExtension : BreastRadBase, IHeaderFragment
	{
		//+ Fields
		//- Fields

		public ServiceRecommendationExtension()
		{
			//+ Constructor
			//- Constructor
		}

		public void Load(ResourceBag resourceBag, Observation resource)
		{
		}

		public void Unload(ResourceBag resourceBag, Observation resource)
		{
		}

	}
}
