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
	public class MGFinding : BreastRadBase, IMGFinding                                                                                         // CSBuilder.cs:262
	//- Header
	{
		//+ Fields
		public List<IAbnormalityCyst> AbnormalityCyst {get;} = new List<IAbnormalityCyst>();                                                      // CSBuilder.cs:210
		public List<IAbnormalityDuct> AbnormalityDuct {get;} = new List<IAbnormalityDuct>();                                                      // CSBuilder.cs:210
		public List<IAbnormalityForeignObject> AbnormalityForeignObject {get;} = new List<IAbnormalityForeignObject>();                           // CSBuilder.cs:210
		public List<IAbnormalityLymphNode> AbnormalityLymphNode {get;} = new List<IAbnormalityLymphNode>();                                       // CSBuilder.cs:210
		public List<IMass> Mass {get;} = new List<IMass>();                                                                                       // CSBuilder.cs:210
		public List<IAssociatedFeatures> AssociatedFeatures {get;} = new List<IAssociatedFeatures>();                                             // CSBuilder.cs:210
		public List<IAbnormalityFibroadenoma> AbnormalityFibroadenoma {get;} = new List<IAbnormalityFibroadenoma>();                              // CSBuilder.cs:210
		public List<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;} = new List<IMGAbnormalityArchitecturalDistortion>();// CSBuilder.cs:210
		public List<IMGAbnormalityAsymmetry> MGAbnormalityAsymmetry {get;} = new List<IMGAbnormalityAsymmetry>();                                 // CSBuilder.cs:210
		public List<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;} = new List<IMGAbnormalityCalcification>();                     // CSBuilder.cs:210
		public List<IMGAbnormalityDensity> MGAbnormalityDensity {get;} = new List<IMGAbnormalityDensity>();                                       // CSBuilder.cs:210
		public List<IMGAbnormalityFatNecrosis> MGAbnormalityFatNecrosis {get;} = new List<IMGAbnormalityFatNecrosis>();                           // CSBuilder.cs:210
		public List<IMGBreastDensity> MGBreastDensity {get;} = new List<IMGBreastDensity>();                                                      // CSBuilder.cs:210
		//- Fields
	}
}
