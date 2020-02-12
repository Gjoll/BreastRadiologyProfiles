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
	public class ShapeVS                                                                                                                       // CSBuilder.cs:333
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:354
		{                                                                                                                                         // CSBuilder.cs:355
		    Coding value;                                                                                                                         // CSBuilder.cs:356
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:357
		    {                                                                                                                                     // CSBuilder.cs:358
		        return tCode.value;                                                                                                               // CSBuilder.cs:359
		    }                                                                                                                                     // CSBuilder.cs:360
		                                                                                                                                          // CSBuilder.cs:361
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:362
		    {                                                                                                                                     // CSBuilder.cs:363
		        this.value= value;                                                                                                                // CSBuilder.cs:364
		    }                                                                                                                                     // CSBuilder.cs:365
		}                                                                                                                                         // CSBuilder.cs:366
		public TCoding Code_IrregularInShape = new TCoding(ShapeCS.Code_IrregularInShape);                                                        // CSBuilder.cs:384
		public TCoding Code_LobulatedInShape = new TCoding(ShapeCS.Code_LobulatedInShape);                                                        // CSBuilder.cs:384
		public TCoding Code_OvalInShape = new TCoding(ShapeCS.Code_OvalInShape);                                                                  // CSBuilder.cs:384
		public TCoding Code_Reniform = new TCoding(ShapeCS.Code_Reniform);                                                                        // CSBuilder.cs:384
		public TCoding Code_RoundInShape = new TCoding(ShapeCS.Code_RoundInShape);                                                                // CSBuilder.cs:384
		                                                                                                                                          // CSBuilder.cs:339
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public ShapeVS()                                                                                                                          // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(this.Code_IrregularInShape);                                                                                         // CSBuilder.cs:387
		    this.Members.Add(this.Code_LobulatedInShape);                                                                                         // CSBuilder.cs:387
		    this.Members.Add(this.Code_OvalInShape);                                                                                              // CSBuilder.cs:387
		    this.Members.Add(this.Code_Reniform);                                                                                                 // CSBuilder.cs:387
		    this.Members.Add(this.Code_RoundInShape);                                                                                             // CSBuilder.cs:387
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
