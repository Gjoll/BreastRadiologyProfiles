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
	public class ShapeCS                                                                                                                       // CSBuilder.cs:441
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/ShapeCS";                                                       // CSBuilder.cs:445
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// A mass that can't be characterized by any specific shape.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_IrregularInShape = new Coding(System, "IrregularInShape", "Irregular in shape");                                // CSBuilder.cs:471
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// A mass that has an undulating  (having a smoothly rising and falling form or outline) contour.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_LobulatedInShape = new Coding(System, "LobulatedInShape", "Lobulated in shape");                                // CSBuilder.cs:471
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// A mass that is elliptical or egg-shaped.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_OvalInShape = new Coding(System, "OvalInShape", "Oval in shape");                                               // CSBuilder.cs:471
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// is a three-dimensional lesion that occupies a space within the breast.
		/// [-- Bi-Rads® Atlas — Mammography Fifth Ed. 2013]
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Reniform = new Coding(System, "Reniform", "Reniform");                                                          // CSBuilder.cs:471
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// A mass that is spherical, ball-shaped, circular or global.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_RoundInShape = new Coding(System, "RoundInShape", "Round in shape");                                            // CSBuilder.cs:471
		//- Fields
	}
}
