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
            if (this.findingBreastTargets == null)
                this.CreateFindingBreastTargets();
            return this.findingBreastTargets;
        }

        ProfileTargetSlice[] findingBreastTargets = null;

        void CreateFindingBreastTargets()
        {
            // ShowChildren = false, to limit depth of resource graph.
            this.findingBreastTargets = new ProfileTargetSlice[]
            {
                new ProfileTargetSlice(this.BiRadsAssessmentCategory.Value(), 1, "1"),
                new ProfileTargetSlice(this.FindingMammo(), 0, "*"),
                new ProfileTargetSlice(this.FindingMri(), 0, "*"),
                new ProfileTargetSlice(this.FindingNM(), 0, "*"),
                new ProfileTargetSlice(this.FindingUltraSound(), 0, "*")
            };
        }
    }
}
