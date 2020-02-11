using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class SectionFindingsLeftBreast : ObservationBase, IFindingBreastFragment
	{
		//+ Fields
		
        public MemberList<IMGFinding> MGFinding {get;}
        public MemberList<IMRIFinding> MRIFinding {get;}
        public MemberList<INMFinding> NMFinding {get;}
        public MemberList<IUSFinding> USFinding {get;}
		//- Fields

		public SectionFindingsLeftBreast()
		{
			//+ Constructor
		
            this.MGFinding = CreateHasMemberList<IMGFinding>(0, -1);
            this.MRIFinding = CreateHasMemberList<IMRIFinding>(0, -1);
            this.NMFinding = CreateHasMemberList<INMFinding>(0, -1);
            this.USFinding = CreateHasMemberList<IUSFinding>(0, -1);
			//- Constructor
		}

	}
}
