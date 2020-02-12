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
	public class AbnormalityDuctTypeCS                                                                                                         // CSBuilder.cs:405
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/AbnormalityDuctTypeCS";                                         // CSBuilder.cs:409
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Duct is considered normal.
		/// It is surrounded by normal cells and collagen in the breast with no abnormalities.
		/// A system of ducts in your breast carries milk to the nipples.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_DuctNormal = new Coding(System, "DuctNormal", "Duct normal");                                                   // CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// The mammographic finding of solitary dilated duct is rare and poorly understood.
		/// There are anecdotal reports of solitary dilated duct as the only mammographic finding of underlying malignancy, indicating its potential importance in the early detection of breast cancer.
		/// However, some investigators have estimated that the finding of solitary dilated duct has a very low risk of malignancy, supporting its assessment as a benign (BI-RADS category 2) or probably benign (BI-RADS category 3) lesion.
		/// Solitary dilated duct also has been reported to coexist with more suspicious mammographic findings, but in such cases the associated mass, grouped microcalcifications, architectural distortion, or developing asymmetry would itself have a sufficiently high likelihood of malignancy to prompt a suspicious (BI-RADS category 4) assessment.Solitary dilated duct is described and illustrated in the current edition of the BI-RADS atlas as the first of four mammographic findings classified as "special cases" .
		/// The accompanying text states that "if unassociated with other suspicious clinical or mammographic findings, it is usually of minor clinical significance".
		/// Insofar as this statement is made under the imprimatur of the widely read BI-RADS atlas, it is likely to influence those practicing radiologists without much, if any, personal experience who encounter the rare finding of solitary dilated duct.
		/// However, to our knowledge, to date there is no large clinical series indicating the positive predictive value for malignancy of solitary dilated duct.
		/// The goal of this largescale study is to report the clinical and pathologic outcomes for the isolated finding of solitary dilated duct identified at screening or diagnostic mammography.
		/// -- https://www.ajronline.org/doi/full/10.2214/AJR.09.2944
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_SolitaryDilatedDuct = new Coding(System, "SolitaryDilatedDuct", "Solitary dilated duct");                       // CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// A noncancerous condition that results in clogged ducts around your nipple.
		/// While it sometimes causes pain, irritation and discharge, it's generally not a cause for concern.
		/// If left untreated, it can eventually obliterate the breast duct.
		/// www.healthline.com > health > duct-ectasia-of-the-breast
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_DuctEctasia = new Coding(System, "DuctEctasia", "Duct ectasia");                                                // CSBuilder.cs:435
		//- Fields
	}
}
