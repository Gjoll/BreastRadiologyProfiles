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
	public class AbnormalityCystTypeCS                                                                                                         // CSBuilder.cs:410
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/AbnormalityCystTypeCS";                                         // CSBuilder.cs:414
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// A cyst is a sac-like pocket of membranous tissue that contains fluid, air, or other substances.
		/// Cysts can grow almost anywhere in your body or under your skin.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Cyst = new Coding(System, "Cyst", "Cyst");                                                                      // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// Complex cysts have irregular or scalloped borders, thick walls, and some evidence of solid areas and/or debris in the fluid.
		/// These solid areas echo back the sound waves from the ultrasound.
		/// A complex cyst is sometimes aspirated, or drained with a fine needle, so that the fluid inside can be tested.
		/// If blood or any unusual cells are present, further testing may be needed to rule out breast cancer.
		/// -- https://www.breastcancer.org/symptoms/benign/cysts
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CystComplex = new Coding(System, "CystComplex", "Cyst complex");                                                // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// Complicated cysts are "in between" simple and complex.
		/// Although they share most of the features of simple cysts, they tend to have some debris inside them and echo back some of the ultrasound waves.
		/// However, they don't have the thick walls or obvious solid components that a complex cyst has.
		/// -- https://www.breastcancer.org/symptoms/benign/cysts
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CystComplicated = new Coding(System, "CystComplicated", "Cyst complicated");                                    // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// Is a sac-like pocket of tissue that contains fluid, air, or other substances.
		/// A Microcyst is small and less than 2-3 mm.
		/// They are often in clusters and only show up on a mammogram or ultrasound.
		/// 
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_CystMicro = new Coding(System, "CystMicro", "Cyst micro");                                                      // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// Oil cysts are filled with fluid that may feel smooth and soft/squishy.
		/// They are caused by the breakdown of fatty tissue.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CystOil = new Coding(System, "CystOil", "Cyst oil");                                                            // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// A simple cyst is a sac-like pocket of membranous tissue that only contains clear fluid.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CystSimple = new Coding(System, "CystSimple", "Cyst simple");                                                   // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// A cyst that is filled with debris and fluid substance.
		/// It Is either considered a complex or complicated cyst.
		/// The type of debris determines what kind of cyst.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CystWithDebris = new Coding(System, "CystWithDebris", "Cyst with debris");                                      // CSBuilder.cs:440
		//- Fields
	}
}
