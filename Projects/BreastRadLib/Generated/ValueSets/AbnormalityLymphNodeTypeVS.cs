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
	public class AbnormalityLymphNodeTypeVS                                                                                                    // CSBuilder.cs:331
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
		public TCoding Code_NodeAxillary = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeAxillary);                                             // CSBuilder.cs:382
		public TCoding Code_NodeEnlarged = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeEnlarged);                                             // CSBuilder.cs:382
		public TCoding Code_NodeFocalCortex = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeFocalCortex);                                       // CSBuilder.cs:382
		public TCoding Code_NodeInfraclavicular = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeInfraclavicular);                               // CSBuilder.cs:382
		public TCoding Code_NodeIntramammary = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeIntramammary);                                     // CSBuilder.cs:382
		public TCoding Code_NodeLymph = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeLymph);                                                   // CSBuilder.cs:382
		public TCoding Code_NodeLymphNormal = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeLymphNormal);                                       // CSBuilder.cs:382
		public TCoding Code_NodeSupraclavicular = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeSupraclavicular);                               // CSBuilder.cs:382
		public TCoding Code_NodeUniformThickness = new TCoding(AbnormalityLymphNodeTypeCS.Code_NodeUniformThickness);                             // CSBuilder.cs:382
		                                                                                                                                          // CSBuilder.cs:337
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:338
		                                                                                                                                          // CSBuilder.cs:339
		public AbnormalityLymphNodeTypeVS()                                                                                                       // CSBuilder.cs:340
		{                                                                                                                                         // CSBuilder.cs:341
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:342
		    this.Members.Add(this.Code_NodeAxillary);                                                                                             // CSBuilder.cs:385
		    this.Members.Add(this.Code_NodeEnlarged);                                                                                             // CSBuilder.cs:385
		    this.Members.Add(this.Code_NodeFocalCortex);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_NodeInfraclavicular);                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_NodeIntramammary);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_NodeLymph);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_NodeLymphNormal);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_NodeSupraclavicular);                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_NodeUniformThickness);                                                                                     // CSBuilder.cs:385
		}                                                                                                                                         // CSBuilder.cs:344
		//- Fields
	}
}
