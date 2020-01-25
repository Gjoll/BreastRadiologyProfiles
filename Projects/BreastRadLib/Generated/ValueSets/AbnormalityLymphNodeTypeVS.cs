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
	public class AbnormalityLymphNodeTypeVS                                                                                                    // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:357
		{                                                                                                                                         // CSBuilder.cs:358
		    Coding value;                                                                                                                         // CSBuilder.cs:359
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        return tCode.value;                                                                                                               // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		                                                                                                                                          // CSBuilder.cs:364
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:365
		    {                                                                                                                                     // CSBuilder.cs:366
		        this.value= value;                                                                                                                // CSBuilder.cs:367
		    }                                                                                                                                     // CSBuilder.cs:368
		}                                                                                                                                         // CSBuilder.cs:369
		public TCoding Code_Axillary = new TCoding(AbnormalityLymphNodeTypeCS.Code_Axillary);                                                     // CSBuilder.cs:387
		public TCoding Code_Enlarged = new TCoding(AbnormalityLymphNodeTypeCS.Code_Enlarged);                                                     // CSBuilder.cs:387
		public TCoding Code_FocalCortex = new TCoding(AbnormalityLymphNodeTypeCS.Code_FocalCortex);                                               // CSBuilder.cs:387
		public TCoding Code_UniformThickness = new TCoding(AbnormalityLymphNodeTypeCS.Code_UniformThickness);                                     // CSBuilder.cs:387
		public TCoding Code_Intramammory = new TCoding(AbnormalityLymphNodeTypeCS.Code_Intramammory);                                             // CSBuilder.cs:387
		public TCoding Code_InternalMargin = new TCoding(AbnormalityLymphNodeTypeCS.Code_InternalMargin);                                         // CSBuilder.cs:387
		public TCoding Code_Normal = new TCoding(AbnormalityLymphNodeTypeCS.Code_Normal);                                                         // CSBuilder.cs:387
		public TCoding Code_PathLymphNode = new TCoding(AbnormalityLymphNodeTypeCS.Code_PathLymphNode);                                           // CSBuilder.cs:387
		                                                                                                                                          // CSBuilder.cs:342
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:343
		                                                                                                                                          // CSBuilder.cs:344
		public AbnormalityLymphNodeTypeVS()                                                                                                       // CSBuilder.cs:345
		{                                                                                                                                         // CSBuilder.cs:346
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:347
		    this.Members.Add(this.Code_Axillary);                                                                                                 // CSBuilder.cs:390
		    this.Members.Add(this.Code_Enlarged);                                                                                                 // CSBuilder.cs:390
		    this.Members.Add(this.Code_FocalCortex);                                                                                              // CSBuilder.cs:390
		    this.Members.Add(this.Code_UniformThickness);                                                                                         // CSBuilder.cs:390
		    this.Members.Add(this.Code_Intramammory);                                                                                             // CSBuilder.cs:390
		    this.Members.Add(this.Code_InternalMargin);                                                                                           // CSBuilder.cs:390
		    this.Members.Add(this.Code_Normal);                                                                                                   // CSBuilder.cs:390
		    this.Members.Add(this.Code_PathLymphNode);                                                                                            // CSBuilder.cs:390
		}                                                                                                                                         // CSBuilder.cs:349
		//- Fields
	}
}
