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
	public class AbnormalityCystTypeVS                                                                                                         // CSBuilder.cs:369
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:390
		{                                                                                                                                         // CSBuilder.cs:391
		    Coding value;                                                                                                                         // CSBuilder.cs:392
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:393
		    {                                                                                                                                     // CSBuilder.cs:394
		        return tCode.value;                                                                                                               // CSBuilder.cs:395
		    }                                                                                                                                     // CSBuilder.cs:396
		                                                                                                                                          // CSBuilder.cs:397
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:398
		    {                                                                                                                                     // CSBuilder.cs:399
		        this.value= value;                                                                                                                // CSBuilder.cs:400
		    }                                                                                                                                     // CSBuilder.cs:401
		}                                                                                                                                         // CSBuilder.cs:402
		public TCoding Code_Cyst = new TCoding(AbnormalityCystTypeCS.Code_Cyst);                                                                  // CSBuilder.cs:420
		public TCoding Code_CystComplex = new TCoding(AbnormalityCystTypeCS.Code_CystComplex);                                                    // CSBuilder.cs:420
		public TCoding Code_CystComplicated = new TCoding(AbnormalityCystTypeCS.Code_CystComplicated);                                            // CSBuilder.cs:420
		public TCoding Code_CystMicro = new TCoding(AbnormalityCystTypeCS.Code_CystMicro);                                                        // CSBuilder.cs:420
		public TCoding Code_CystOil = new TCoding(AbnormalityCystTypeCS.Code_CystOil);                                                            // CSBuilder.cs:420
		public TCoding Code_CystSimple = new TCoding(AbnormalityCystTypeCS.Code_CystSimple);                                                      // CSBuilder.cs:420
		public TCoding Code_CystWithDebris = new TCoding(AbnormalityCystTypeCS.Code_CystWithDebris);                                              // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:375
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:376
		                                                                                                                                          // CSBuilder.cs:377
		public AbnormalityCystTypeVS()                                                                                                            // CSBuilder.cs:378
		{                                                                                                                                         // CSBuilder.cs:379
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:380
		    this.Members.Add(this.Code_Cyst);                                                                                                     // CSBuilder.cs:423
		    this.Members.Add(this.Code_CystComplex);                                                                                              // CSBuilder.cs:423
		    this.Members.Add(this.Code_CystComplicated);                                                                                          // CSBuilder.cs:423
		    this.Members.Add(this.Code_CystMicro);                                                                                                // CSBuilder.cs:423
		    this.Members.Add(this.Code_CystOil);                                                                                                  // CSBuilder.cs:423
		    this.Members.Add(this.Code_CystSimple);                                                                                               // CSBuilder.cs:423
		    this.Members.Add(this.Code_CystWithDebris);                                                                                           // CSBuilder.cs:423
		}                                                                                                                                         // CSBuilder.cs:382
		//- Fields
	}
}
