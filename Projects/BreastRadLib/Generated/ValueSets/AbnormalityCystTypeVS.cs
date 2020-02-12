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
	public class AbnormalityCystTypeVS                                                                                                         // CSBuilder.cs:338
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:359
		{                                                                                                                                         // CSBuilder.cs:360
		    Coding value;                                                                                                                         // CSBuilder.cs:361
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:362
		    {                                                                                                                                     // CSBuilder.cs:363
		        return tCode.value;                                                                                                               // CSBuilder.cs:364
		    }                                                                                                                                     // CSBuilder.cs:365
		                                                                                                                                          // CSBuilder.cs:366
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:367
		    {                                                                                                                                     // CSBuilder.cs:368
		        this.value= value;                                                                                                                // CSBuilder.cs:369
		    }                                                                                                                                     // CSBuilder.cs:370
		}                                                                                                                                         // CSBuilder.cs:371
		public TCoding Code_Cyst = new TCoding(AbnormalityCystTypeCS.Code_Cyst);                                                                  // CSBuilder.cs:389
		public TCoding Code_CystComplex = new TCoding(AbnormalityCystTypeCS.Code_CystComplex);                                                    // CSBuilder.cs:389
		public TCoding Code_CystComplicated = new TCoding(AbnormalityCystTypeCS.Code_CystComplicated);                                            // CSBuilder.cs:389
		public TCoding Code_CystMicro = new TCoding(AbnormalityCystTypeCS.Code_CystMicro);                                                        // CSBuilder.cs:389
		public TCoding Code_CystOil = new TCoding(AbnormalityCystTypeCS.Code_CystOil);                                                            // CSBuilder.cs:389
		public TCoding Code_CystSimple = new TCoding(AbnormalityCystTypeCS.Code_CystSimple);                                                      // CSBuilder.cs:389
		public TCoding Code_CystWithDebris = new TCoding(AbnormalityCystTypeCS.Code_CystWithDebris);                                              // CSBuilder.cs:389
		                                                                                                                                          // CSBuilder.cs:344
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:345
		                                                                                                                                          // CSBuilder.cs:346
		public AbnormalityCystTypeVS()                                                                                                            // CSBuilder.cs:347
		{                                                                                                                                         // CSBuilder.cs:348
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:349
		    this.Members.Add(this.Code_Cyst);                                                                                                     // CSBuilder.cs:392
		    this.Members.Add(this.Code_CystComplex);                                                                                              // CSBuilder.cs:392
		    this.Members.Add(this.Code_CystComplicated);                                                                                          // CSBuilder.cs:392
		    this.Members.Add(this.Code_CystMicro);                                                                                                // CSBuilder.cs:392
		    this.Members.Add(this.Code_CystOil);                                                                                                  // CSBuilder.cs:392
		    this.Members.Add(this.Code_CystSimple);                                                                                               // CSBuilder.cs:392
		    this.Members.Add(this.Code_CystWithDebris);                                                                                           // CSBuilder.cs:392
		}                                                                                                                                         // CSBuilder.cs:351
		//- Fields
	}
}
