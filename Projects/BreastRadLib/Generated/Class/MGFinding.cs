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
	public class MGFinding : BreastRadBase, IMGFinding
	//- Header
	{
		//+ Fields
		public List<IAbnormalityCyst> AbnormalityCyst {get;} = new List<IAbnormalityCyst>();
		public List<IAbnormalityDuct> AbnormalityDuct {get;} = new List<IAbnormalityDuct>();
		public List<IAbnormalityForeignObject> AbnormalityForeignObject {get;} = new List<IAbnormalityForeignObject>();
		public List<IAbnormalityLymphNode> AbnormalityLymphNode {get;} = new List<IAbnormalityLymphNode>();
		public List<IMass> Mass {get;} = new List<IMass>();
		public List<IAssociatedFeatures> AssociatedFeatures {get;} = new List<IAssociatedFeatures>();
		public List<IAbnormalityFibroadenoma> AbnormalityFibroadenoma {get;} = new List<IAbnormalityFibroadenoma>();
		public List<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;} = new List<IMGAbnormalityArchitecturalDistortion>();
		public List<IMGAbnormalityAsymmetry> MGAbnormalityAsymmetry {get;} = new List<IMGAbnormalityAsymmetry>();
		public List<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;} = new List<IMGAbnormalityCalcification>();
		public List<IMGAbnormalityDensity> MGAbnormalityDensity {get;} = new List<IMGAbnormalityDensity>();
		public List<IMGAbnormalityFatNecrosis> MGAbnormalityFatNecrosis {get;} = new List<IMGAbnormalityFatNecrosis>();
		public List<IMGBreastDensity> MGBreastDensity {get;} = new List<IMGBreastDensity>();
		//- Fields
	}
}
