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
	public class BreastLocationClockCS                                                                                                         // CSBuilder.cs:403
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/BreastLocationClockCS";                                         // CSBuilder.cs:407
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Just like the hands of a clock, this is how doctors describe position of the tumor in the breast.
		/// 1 o'clock position is at the 1 o'clock position and in the Upper Inner Quandrant (UIQ) of the breast.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_1OClock = new Coding(System, "1O'clock", "1 o'clock");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Just like the hands of a clock, this is how doctors describe position of the tumor in the breast.
		/// 2 o'clock position is at the 2 o'clock position and in the Upper Inner Quandrant (UIQ) of the breast.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_2OClock = new Coding(System, "2O'clock", "2 o'clock");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Just like the hands of a clock, this is how doctors describe position of the tumor in the breast.
		/// 3 o'clock position is at the 3 o'clock position.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_3OClock = new Coding(System, "3O'clock", "3 o'clock");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Just like the hands of a clock, this is how doctors describe position of the tumor in the breast.
		/// 4 o'clock position is at the 4 o'clock position and in the Lower Inner Quandrant (LIQ) of the breast.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_4OClock = new Coding(System, "4O'clock", "4 o'clock");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Just like the hands of a clock, this is how doctors describe position of the tumor in the breast.
		/// 5 o'clock position is at the 5 o'clock position and in the Lower Inner Quandrant (LIQ) of the breast.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_5OClock = new Coding(System, "5O'clock", "5 o'clock");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Just like the hands of a clock, this is how doctors describe position of the tumor in the breast.
		/// 6 o'clock position is at the 6 o'clock position.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_6OClock = new Coding(System, "6O'clock", "6 o'clock");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Just like the hands of a clock, this is how doctors describe position of the tumor in the breast.
		/// 7 o'clock position is at the 7 o'clock position and in the Lower Outer Quandrant (LOQ) of the breast.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_7OClock = new Coding(System, "7O'clock", "7 o'clock");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Just like the hands of a clock, this is how doctors describe position of the tumor in the breast.
		/// 8 o'clock position is at the 8 o'clock position and in the Lower Outer Quandrant (LOQ) of the breast.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_8OClock = new Coding(System, "8O'clock", "8 o'clock");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Just like the hands of a clock, this is how doctors describe position of the tumor in the breast.
		/// 9 o'clock position is at the 9 o'clock position.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_9OClock = new Coding(System, "9O'clock", "9 o'clock");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Just like the hands of a clock, this is how doctors describe position of the tumor in the breast.
		/// 10 o'clock position is at the 10 o'clock position and in the Upper Outer Quandrant (UOQ) of the breast.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_10OClock = new Coding(System, "10O'clock", "10 o'clock");                                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Just like the hands of a clock, this is how doctors describe position of the tumor in the breast.
		/// 11 o'clock position is at the 11 o'clock position and in the Upper Outer Quandrant (UOQ) of the breast.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_11OClock = new Coding(System, "11O'clock", "11 o'clock");                                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Just like the hands of a clock, this is how doctors describe position of the tumor in the breast.
		/// 12 o'clock position is at the 12 o'clock position.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_12OClock = new Coding(System, "12O'clock", "12 o'clock");                                                       // CSBuilder.cs:433
		//- Fields
	}
}
