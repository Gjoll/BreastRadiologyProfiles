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
	public class BreastLocationClockCS                                                                                                         // CSBuilder.cs:475
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/BreastLocationClockCS";                                         // CSBuilder.cs:479
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// 12-OClock
		/// </summary>
		public static Coding Code_1200OClock = new Coding(System, "12:00-OClock", "12:00-OClock");                                                // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// 1:00-OClock
		/// </summary>
		public static Coding Code_100OClock = new Coding(System, "1:00-OClock", "1:00-OClock");                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// 2:00-OClock
		/// </summary>
		public static Coding Code_200OClock = new Coding(System, "2:00-OClock", "2:00-OClock");                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// 3:00-OClock
		/// </summary>
		public static Coding Code_300OClock = new Coding(System, "3:00-OClock", "3:00-OClock");                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// 4:00-OClock
		/// </summary>
		public static Coding Code_400OClock = new Coding(System, "4:00-OClock", "4:00-OClock");                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// 5:00-OClock
		/// </summary>
		public static Coding Code_500OClock = new Coding(System, "5:00-OClock", "5:00-OClock");                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// 6:00-OClock
		/// </summary>
		public static Coding Code_600OClock = new Coding(System, "6:00-OClock", "6:00-OClock");                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// 7:00-OClock
		/// </summary>
		public static Coding Code_700OClock = new Coding(System, "7:00-OClock", "7:00-OClock");                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// 8:00-OClock
		/// </summary>
		public static Coding Code_800OClock = new Coding(System, "8:00-OClock", "8:00-OClock");                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// 9:00-OClock
		/// </summary>
		public static Coding Code_900OClock = new Coding(System, "9:00-OClock", "9:00-OClock");                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// 10:00-OClock
		/// </summary>
		public static Coding Code_1000OClock = new Coding(System, "10:00-OClock", "10:00-OClock");                                                // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// 11:00-OClock
		/// </summary>
		public static Coding Code_1100OClock = new Coding(System, "11:00-OClock", "11:00-OClock");                                                // CSBuilder.cs:505
		//- Fields
	}
}
