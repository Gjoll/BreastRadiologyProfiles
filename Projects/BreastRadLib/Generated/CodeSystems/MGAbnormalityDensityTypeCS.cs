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
	public class MGAbnormalityDensityTypeCS                                                                                                    // CSBuilder.cs:410
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/MGAbnormalityDensityTypeCS";                                    // CSBuilder.cs:414
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Density = new Coding(System, "Density", "Density");                                                             // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_DensityFocalAsymmetry = new Coding(System, "DensityFocalAsymmetry", "Density focal asymmetry");                 // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_DensityNodular = new Coding(System, "DensityNodular", "Density nodular");                                       // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_DensityTubular = new Coding(System, "DensityTubular", "Density tubular");                                       // CSBuilder.cs:440
		//- Fields
	}
}
