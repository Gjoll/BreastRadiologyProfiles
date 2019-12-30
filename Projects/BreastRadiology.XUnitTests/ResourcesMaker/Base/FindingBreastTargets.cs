using FhirKhit.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        void AddFindingBreastTargets(SDefEditor e)
        {
            if (Self.Component_HasMember)
            {
                ProfileTargetSlice[] findingBreastTargets = new ProfileTargetSlice[]
                {
                new ProfileTargetSlice(Self.BiRadsAssessmentCategory.Value(), 1, "1"),
                new ProfileTargetSlice(Self.FindingMammo.Value(), 0, "*"),
                new ProfileTargetSlice(Self.FindingMri.Value(), 0, "*"),
                new ProfileTargetSlice(Self.FindingNM.Value(), 0, "*"),
                new ProfileTargetSlice(Self.FindingUltraSound.Value(), 0, "*")
                };

                e.SliceByUrl("hasMember", findingBreastTargets);
                e.AddProfileTargets(findingBreastTargets);
            }
            else
            {
                ProfileTargetSlice[] findingBreastTargets = new ProfileTargetSlice[]
                {
                new ProfileTargetSlice(Self.FindingMammo.Value(), 0, "*"),
                new ProfileTargetSlice(Self.FindingMri.Value(), 0, "*"),
                new ProfileTargetSlice(Self.FindingNM.Value(), 0, "*"),
                new ProfileTargetSlice(Self.FindingUltraSound.Value(), 0, "*")
                };

                e.SliceByUrl("hasMember", findingBreastTargets);
                e.AddProfileTargets(findingBreastTargets);

                Self.ComponentSliceConsistentWith(e);
            }
        }
    }
}
