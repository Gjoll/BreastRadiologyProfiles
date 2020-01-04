using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        void AddFindingBreastTargets(SDefEditor e)
        {
            PreFhir.ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
            Self.SliceTargetReference(e, sliceElementDef, Self.FindingMammo.Value(), 0, "*");
            Self.SliceTargetReference(e, sliceElementDef, Self.FindingMri.Value(), 0, "*");
            Self.SliceTargetReference(e, sliceElementDef, Self.FindingNM.Value(), 0, "*");
            Self.SliceTargetReference(e, sliceElementDef, Self.FindingUltraSound.Value(), 0, "*");
        }
    }
}
