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
	public class ShapeCS                                                                                                                       // CSBuilder.cs:408
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/ShapeCS";                                                       // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// The shape is neither round nor oval.
		/// For mammography, use of this descriptor usually implies a suspicious finding.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_IrregularInShape = new Coding(System, "IrregularInShape", "Irregular in shape");                                // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Shape is elliptical or egg-shaped (may include 2 or 3 undulations, , i.e., "gently lobulated" or "macrolobulated").
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_OvalInShape = new Coding(System, "OvalInShape", "Oval in shape");                                               // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// A mass that is spherical, ball-shaped, circular, or globular in shape.
		/// A round mass has an anteroposterior diameter equal to its transverse diameter
		/// and to qualify as a ROUND mass, it must be circular in perpendicular projections.
		/// Breast masses with a ROUND shape are not commonly seen with breast ultrasound.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_RoundInShape = new Coding(System, "RoundInShape", "Round in shape");                                            // CSBuilder.cs:438
		//- Fields
	}
}
