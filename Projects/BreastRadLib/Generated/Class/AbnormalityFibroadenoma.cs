using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class AbnormalityFibroadenoma : ObservationBase, IObservationLeafFragment, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, IBreastRadObservationNoComponentFragment, ICommonComponentsFragment, IShapeComponentsFragment, IObservedCountFragment, IObservedDistributionFragment, IObservedSizeFragment, IPreviouslyDemonstratedByFragment, IAssociatedFeaturesHasMemberFragment
	{
		//+ Fields
		
        public MemberList<IAssociatedFeatures> AssociatedFeatures {get;}
		//- Fields

		public AbnormalityFibroadenoma()
		{
			//+ Constructor
		
            this.AssociatedFeatures = CreateHasMemberList<IAssociatedFeatures>(0, 1);
			//- Constructor
		}

	}
}
