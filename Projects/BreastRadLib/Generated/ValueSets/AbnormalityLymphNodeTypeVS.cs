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
	public class AbnormalityLymphNodeTypeVS                                                                                                    // CSBuilder.cs:361
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:382
		{                                                                                                                                         // CSBuilder.cs:383
		    Coding value;                                                                                                                         // CSBuilder.cs:384
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:385
		    {                                                                                                                                     // CSBuilder.cs:386
		        return tCode.value;                                                                                                               // CSBuilder.cs:387
		    }                                                                                                                                     // CSBuilder.cs:388
		                                                                                                                                          // CSBuilder.cs:389
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:390
		    {                                                                                                                                     // CSBuilder.cs:391
		        this.value= value;                                                                                                                // CSBuilder.cs:392
		    }                                                                                                                                     // CSBuilder.cs:393
		}                                                                                                                                         // CSBuilder.cs:394
		public TCoding Code_Axillary = new TCoding(AbnormalityLymphNodeTypeCS.Code_Axillary);                                                     // CSBuilder.cs:412
		public TCoding Code_Enlarged = new TCoding(AbnormalityLymphNodeTypeCS.Code_Enlarged);                                                     // CSBuilder.cs:412
		public TCoding Code_FocalCortex = new TCoding(AbnormalityLymphNodeTypeCS.Code_FocalCortex);                                               // CSBuilder.cs:412
		public TCoding Code_UniformThickness = new TCoding(AbnormalityLymphNodeTypeCS.Code_UniformThickness);                                     // CSBuilder.cs:412
		public TCoding Code_Intramammory = new TCoding(AbnormalityLymphNodeTypeCS.Code_Intramammory);                                             // CSBuilder.cs:412
		public TCoding Code_InternalMargin = new TCoding(AbnormalityLymphNodeTypeCS.Code_InternalMargin);                                         // CSBuilder.cs:412
		public TCoding Code_Normal = new TCoding(AbnormalityLymphNodeTypeCS.Code_Normal);                                                         // CSBuilder.cs:412
		public TCoding Code_PathLymphNode = new TCoding(AbnormalityLymphNodeTypeCS.Code_PathLymphNode);                                           // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:367
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:368
		                                                                                                                                          // CSBuilder.cs:369
		public AbnormalityLymphNodeTypeVS()                                                                                                       // CSBuilder.cs:370
		{                                                                                                                                         // CSBuilder.cs:371
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:372
		    this.Members.Add(this.Code_Axillary);                                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_Enlarged);                                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_FocalCortex);                                                                                              // CSBuilder.cs:415
		    this.Members.Add(this.Code_UniformThickness);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_Intramammory);                                                                                             // CSBuilder.cs:415
		    this.Members.Add(this.Code_InternalMargin);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_Normal);                                                                                                   // CSBuilder.cs:415
		    this.Members.Add(this.Code_PathLymphNode);                                                                                            // CSBuilder.cs:415
		}                                                                                                                                         // CSBuilder.cs:374
		//- Fields
	}
}
