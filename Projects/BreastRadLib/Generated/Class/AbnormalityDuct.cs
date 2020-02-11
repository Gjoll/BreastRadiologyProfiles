using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class AbnormalityDuct : ObservationBase, IObservationLeafFragment, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoValueFragment, IBreastRadObservationNoComponentFragment, ICommonComponentsFragment, IShapeComponentsFragment, IObservedCountFragment, IObservedDistributionFragment, IObservedSizeFragment, INotPreviouslySeenComponentFragment, ICorrespondsWithFragment, IPreviouslyDemonstratedByFragment, IConsistentWithHasMemberFragment
	{
		//+ Fields
		
        public MemberList<IConsistentWith> ConsistentWith {get;}
		//- Fields

		public AbnormalityDuct()
		{
			//+ Constructor
		
            this.ConsistentWith = CreateHasMemberList<IConsistentWith>(0, -1);
			//- Constructor
		}

		//+ Methods
		//- Methods
	}
}
