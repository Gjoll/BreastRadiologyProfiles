using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class AbnormalityForeignObject : ObservationBase, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, IBreastRadObservationNoComponentFragment, ICommonComponentsFragment, INotPreviouslySeenComponentFragment, ICorrespondsWithFragment, IBiRadFragment, IPreviouslyDemonstratedByFragment, IAssociatedFeaturesHasMemberFragment, IConsistentWithHasMemberFragment
	{
		//+ Fields
		
        public MemberList<IAssociatedFeatures> AssociatedFeatures {get;}
        public MemberList<IConsistentWith> ConsistentWith {get;}
		//- Fields

		public AbnormalityForeignObject()
		{
			//+ Constructor
		
            this.AssociatedFeatures = CreateHasMemberList<IAssociatedFeatures>(0, 1);
            this.ConsistentWith = CreateHasMemberList<IConsistentWith>(0, -1);
			//- Constructor
		}

		//+ Methods
		//- Methods
	}
}
