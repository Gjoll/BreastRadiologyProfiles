using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class MGAbnormalityDensity : ObservationBase, IObservationLeafFragment, IBreastRadObservationNoDeviceFragment, IBreastRadObservationNoComponentFragment, IBreastRadObservationNoValueFragment, ICommonComponentsFragment, IShapeComponentsFragment, INotPreviouslySeenComponentFragment, IObservedCountFragment, IObservedSizeFragment, IObservedDistributionFragment, ICorrespondsWithFragment, IPreviouslyDemonstratedByFragment, IAssociatedFeaturesHasMemberFragment, IConsistentWithHasMemberFragment
	{
		//+ Fields
		
        public MemberList<IAssociatedFeatures> AssociatedFeatures {get;}
        public MemberList<IConsistentWith> ConsistentWith {get;}
		//- Fields

		public MGAbnormalityDensity(Observation resource) : this()
		{
			this.SetResource(resource);
		}

		public MGAbnormalityDensity() : base()
		{
			//+ Constructor
		
            this.AssociatedFeatures = CreateHasMemberList<IAssociatedFeatures>(0, 1);
            this.ConsistentWith = CreateHasMemberList<IConsistentWith>(0, -1);
			//- Constructor
		}

		public void Write()
		{
		//+ WriteCode
		//- WriteCode
		}

		public void Read(ResourceBag resourceBag)
		{
		//+ ReadCode
		//- ReadCode
		}

		//+ Methods
		/// <summary>
		/// Bind fhir resource to this
		/// </summary>
		public override void SetResource(Base resource)                                                                                           // CSDefineBase.cs:113
		{                                                                                                                                         // CSDefineBase.cs:114
		    Observation r = resource as Observation;                                                                                              // CSDefineBase.cs:115
		    if (r == null)                                                                                                                        // CSDefineBase.cs:116
		        throw new Exception("resource must be of type Observation");                                                                      // CSDefineBase.cs:117
		    this.resource = r;                                                                                                                    // CSDefineBase.cs:118
		    SetProfileUrl("http://hl7.org/fhir/us/breast-radiology/StructureDefinition/MGAbnormalityDensity");                                    // CSDefineBase.cs:119
		}                                                                                                                                         // CSDefineBase.cs:120
		//- Methods
	}
}
