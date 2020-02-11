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
	public class NotPreviouslySeenCodeSystemCS                                                                                                 // CSBuilder.cs:441
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/NotPreviouslySeenCodeSystemCS";                                 // CSBuilder.cs:445
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_ClinicalExam = new Coding(System, "ClinicalExam", "Clinical exam");                                             // CSBuilder.cs:471
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// Breast ductography (a.k.a.
		/// galactography) is an imaging technique which is used to evaluate lesions causing nipple discharge.
		/// It helps in precisely locating the mass within breast tissue and gives useful information for surgical approach and planning.A blunt-tipped sialogram needle (30-gauge) is used for performing the ductogram.
		/// The abnormal duct is identified and cannulated.
		/// -- https://radiopaedia.org/articles/breast-ductography-1?lang=us
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Ductogram = new Coding(System, "Ductogram", "Ductogram");                                                       // CSBuilder.cs:471
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// An X-Ray picture of the breast.
		/// It's used to look for early signs of breast cancer.
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Mammogram = new Coding(System, "Mammogram", "Mammogram");                                                       // CSBuilder.cs:471
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// Magnetic Resonance Imaging (MRI) is a test that uses powerful magnets, radio waves, and a computer to make detailed pictures inside your body.
		/// It helps a doctor to diagnose a disease or injury.
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_MRI = new Coding(System, "MRI", "MRI");                                                                         // CSBuilder.cs:471
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_OutsideExam = new Coding(System, "OutsideExam", "Outside exam");                                                // CSBuilder.cs:471
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// This is a type of breast imaging that is used to detect cancer cells in the breasts of some women who have had abnormal mammograms.
		/// 
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_Scintimammography = new Coding(System, "Scintimammography", "Scintimammography");                               // CSBuilder.cs:471
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// Uses soundwaves to develop ultrasound images.
		/// This information is relayed in real time to produce images on a computer screen.
		/// This can help diagnose and treat disease or conditions.
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Ultrasound = new Coding(System, "Ultrasound", "Ultrasound");                                                    // CSBuilder.cs:471
		//- Fields
	}
}
