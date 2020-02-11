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
	public class AbnormalityLymphNodeTypeVS                                                                                                    // CSBuilder.cs:369
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
		public TCoding Code_NodeAxillary = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeAxillary);                                             // CSBuilder.cs:420
		public TCoding Code_NodeEnlarged = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeEnlarged);                                             // CSBuilder.cs:420
		public TCoding Code_NodeFocalCortex = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeFocalCortex);                                       // CSBuilder.cs:420
		public TCoding Code_NodeInfraclavicular = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeInfraclavicular);                               // CSBuilder.cs:420
		public TCoding Code_NodeIntramammary = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeIntramammary);                                     // CSBuilder.cs:420
		public TCoding Code_NodeLymph = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeLymph);                                                   // CSBuilder.cs:420
		public TCoding Code_NodeLymphNormal = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeLymphNormal);                                       // CSBuilder.cs:420
		public TCoding Code_NodeSupraclavicular = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeSupraclavicular);                               // CSBuilder.cs:420
		public TCoding Code_NodeUniformThickness = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeUniformThickness);                             // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:375
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:376
		                                                                                                                                          // CSBuilder.cs:377
		public AbnormalityLymphNodeTypeVS()                                                                                                       // CSBuilder.cs:378
		{                                                                                                                                         // CSBuilder.cs:379
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:380
		    this.Members.Add(this.Code_NodeAxillary);                                                                                             // CSBuilder.cs:423
		    this.Members.Add(this.Code_NodeEnlarged);                                                                                             // CSBuilder.cs:423
		    this.Members.Add(this.Code_NodeFocalCortex);                                                                                          // CSBuilder.cs:423
		    this.Members.Add(this.Code_NodeInfraclavicular);                                                                                      // CSBuilder.cs:423
		    this.Members.Add(this.Code_NodeIntramammary);                                                                                         // CSBuilder.cs:423
		    this.Members.Add(this.Code_NodeLymph);                                                                                                // CSBuilder.cs:423
		    this.Members.Add(this.Code_NodeLymphNormal);                                                                                          // CSBuilder.cs:423
		    this.Members.Add(this.Code_NodeSupraclavicular);                                                                                      // CSBuilder.cs:423
		    this.Members.Add(this.Code_NodeUniformThickness);                                                                                     // CSBuilder.cs:423
		}                                                                                                                                         // CSBuilder.cs:382
		//- Fields
	}
}
