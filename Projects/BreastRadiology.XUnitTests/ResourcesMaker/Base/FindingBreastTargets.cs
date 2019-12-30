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
            if (Self.findingBreastTargets == null)
                Self.CreateFindingBreastTargets();
            return Self.findingBreastTargets;
        }

        ProfileTargetSlice[] findingBreastTargets = null;

        void CreateFindingBreastTargets()
        {
            // ShowChildren = false, to limit depth of resource graph.
            Self.findingBreastTargets = new ProfileTargetSlice[]
            {
                new ProfileTargetSlice(Self.BiRadsAssessmentCategory.Value(), 1, "1"),
                new ProfileTargetSlice(Self.FindingMammo.Value(), 0, "*"),
                new ProfileTargetSlice(Self.FindingMri.Value(), 0, "*"),
                new ProfileTargetSlice(Self.FindingNM.Value(), 0, "*"),
                new ProfileTargetSlice(Self.FindingUltraSound.Value(), 0, "*")
            };
        }
    }
}
