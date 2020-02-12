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
	public class AbnormalityCystTypeVS                                                                                                         // CSBuilder.cs:331
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:352
		{                                                                                                                                         // CSBuilder.cs:353
		    Coding value;                                                                                                                         // CSBuilder.cs:354
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:355
		    {                                                                                                                                     // CSBuilder.cs:356
		        return tCode.value;                                                                                                               // CSBuilder.cs:357
		    }                                                                                                                                     // CSBuilder.cs:358
		                                                                                                                                          // CSBuilder.cs:359
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        this.value= value;                                                                                                                // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		}                                                                                                                                         // CSBuilder.cs:364
		public TCoding Code_Cyst = new TCoding(AbnormalityCystTypeCS.Code_Cyst);                                                                  // CSBuilder.cs:382
		public TCoding Code_CystComplex = new TCoding(AbnormalityCystTypeCS.Code_CystComplex);                                                    // CSBuilder.cs:382
		public TCoding Code_CystComplicated = new TCoding(AbnormalityCystTypeCS.Code_CystComplicated);                                            // CSBuilder.cs:382
		public TCoding Code_CystMicro = new TCoding(AbnormalityCystTypeCS.Code_CystMicro);                                                        // CSBuilder.cs:382
		public TCoding Code_CystOil = new TCoding(AbnormalityCystTypeCS.Code_CystOil);                                                            // CSBuilder.cs:382
		public TCoding Code_CystSimple = new TCoding(AbnormalityCystTypeCS.Code_CystSimple);                                                      // CSBuilder.cs:382
		public TCoding Code_CystWithDebris = new TCoding(AbnormalityCystTypeCS.Code_CystWithDebris);                                              // CSBuilder.cs:382
		                                                                                                                                          // CSBuilder.cs:337
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:338
		                                                                                                                                          // CSBuilder.cs:339
		public AbnormalityCystTypeVS()                                                                                                            // CSBuilder.cs:340
		{                                                                                                                                         // CSBuilder.cs:341
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:342
		    this.Members.Add(this.Code_Cyst);                                                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_CystComplex);                                                                                              // CSBuilder.cs:385
		    this.Members.Add(this.Code_CystComplicated);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_CystMicro);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_CystOil);                                                                                                  // CSBuilder.cs:385
		    this.Members.Add(this.Code_CystSimple);                                                                                               // CSBuilder.cs:385
		    this.Members.Add(this.Code_CystWithDebris);                                                                                           // CSBuilder.cs:385
		}                                                                                                                                         // CSBuilder.cs:344
		//- Fields
	}
}
