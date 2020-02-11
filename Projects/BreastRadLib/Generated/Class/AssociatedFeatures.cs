using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class AssociatedFeatures : ObservationBase, IObservationSectionFragment
	{
		//+ Fields
		
        public MemberList<IMGAbnormalityArchitecturalDistortion> MGAbnormalityArchitecturalDistortion {get;}
        public MemberList<IMGAbnormalityCalcification> MGAbnormalityCalcification {get;}
        public MemberList<IObservedFeature> ObservedFeature {get;}
		//- Fields

		public AssociatedFeatures(Observation resource) : base(resource)
		{
			//+ Constructor
		
            this.MGAbnormalityArchitecturalDistortion = CreateHasMemberList<IMGAbnormalityArchitecturalDistortion>(0, -1);
            this.MGAbnormalityCalcification = CreateHasMemberList<IMGAbnormalityCalcification>(0, -1);
            this.ObservedFeature = CreateHasMemberList<IObservedFeature>(0, -1);
			//- Constructor
		}

		public void Write()
		{
		//+ WriteCode
		//- WriteCode
		}

		public void Read()
		{
		//+ ReadCode
		//- ReadCode
		}

		//+ Methods
		//- Methods
	}
}
