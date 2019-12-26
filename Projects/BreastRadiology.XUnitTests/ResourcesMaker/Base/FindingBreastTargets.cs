using FhirKhit.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        ProfileTargetSlice[] FindingBreastTargets()
        {
            if (ResourcesMaker.Self.findingBreastTargets == null)
                ResourcesMaker.Self.CreateFindingBreastTargets();
            return ResourcesMaker.Self.findingBreastTargets;
        }

        ProfileTargetSlice[] findingBreastTargets = null;

        void CreateFindingBreastTargets()
        {
            // ShowChildren = false, to limit depth of resource graph.
            ResourcesMaker.Self.findingBreastTargets = new ProfileTargetSlice[]
            {
                new ProfileTargetSlice(ResourcesMaker.Self.BiRadsAssessmentCategory.Value(), 1, "1"),
                new ProfileTargetSlice(ResourcesMaker.Self.FindingMammo.Value(), 0, "*"),
                new ProfileTargetSlice(ResourcesMaker.Self.FindingMri.Value(), 0, "*"),
                new ProfileTargetSlice(ResourcesMaker.Self.FindingNM.Value(), 0, "*"),
                new ProfileTargetSlice(ResourcesMaker.Self.FindingUltraSound.Value(), 0, "*")
            };
        }
    }
}
