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
            ProfileTargetSlice[] findingBreastTargets = new ProfileTargetSlice[]
            {
                new ProfileTargetSlice(Self.FindingMammo.Value(), 0, "*"),
                new ProfileTargetSlice(Self.FindingMri.Value(), 0, "*"),
                new ProfileTargetSlice(Self.FindingNM.Value(), 0, "*"),
                new ProfileTargetSlice(Self.FindingUltraSound.Value(), 0, "*")
            };

            e.SliceByUrl("hasMember", findingBreastTargets);
            e.AddProfileTargets(findingBreastTargets);
        }
    }
}
