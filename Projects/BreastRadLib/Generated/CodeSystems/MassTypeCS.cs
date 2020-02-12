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
	public class MassTypeCS                                                                                                                    // CSBuilder.cs:403
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/MassTypeCS";                                                    // CSBuilder.cs:407
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A breast mass has been identified in the breast.
		/// This is also known as a breast lump.
		/// It feels different from the surrounding tissue.
		/// Breast pain, nipple discharge, or skin changes may be present.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Mass = new Coding(System, "Mass", "Mass");                                                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// An intraductal mass has been identified in the breast.
		/// It is a lump that originates in one or more of the milk ducts in the breast.
		/// 
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_MassIntraductal = new Coding(System, "MassIntraductal", "Mass intraductal");                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A mass that is partially solid has been identified in the breast.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MassPartiallySolid = new Coding(System, "MassPartiallySolid", "Mass partially solid");                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MassSkinATLASIsSkinLesion = new Coding(System, "MassSkinATLASIsSkinLesion", "Mass skin ATLAS is skin lesion");  // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MassSolid = new Coding(System, "MassSolid", "Mass solid");                                                      // CSBuilder.cs:433
		//- Fields
	}
}
