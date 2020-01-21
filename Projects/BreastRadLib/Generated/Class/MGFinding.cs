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
		public List<AbnormalityCyst> abnormalityCyst;
		public List<AbnormalityDuct> abnormalityDuct;
		public List<AbnormalityForeignObject> abnormalityForeignObject;
		public List<AbnormalityLymphNode> abnormalityLymphNode;
		public List<Mass> mass;
		public List<AssociatedFeatures> associatedFeatures;
		public List<AbnormalityFibroadenoma> abnormalityFibroadenoma;
		public List<MGAbnormalityArchitecturalDistortion> mGAbnormalityArchitecturalDistortion;
		public List<MGAbnormalityAsymmetry> mGAbnormalityAsymmetry;
		public List<MGAbnormalityCalcification> mGAbnormalityCalcification;
		public List<MGAbnormalityDensity> mGAbnormalityDensity;
		public List<MGAbnormalityFatNecrosis> mGAbnormalityFatNecrosis;
		public List<MGBreastDensity> mGBreastDensity;
		//- Fields
	}
}
