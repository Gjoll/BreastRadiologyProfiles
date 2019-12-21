using FhirKhit.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using VTask = System.Threading.Tasks.Task;

namespace BreastRadiology.XUnitTests
{
    using XTask = System.Threading.Tasks.Task<ProfileTargetSlice[]>;
    partial class ResourcesMaker : ConverterBase
    {
        async XTask FindingBreastTargets()
        {
            if (this.findingBreastTargets == null)
                await this.CreateFindingBreastTargets();
            return this.findingBreastTargets;
        }

        ProfileTargetSlice[] findingBreastTargets = null;

        async VTask CreateFindingBreastTargets()
        {
            // ShowChildren = false, to limit depth of resource graph.
            this.findingBreastTargets = new ProfileTargetSlice[]
            {
                new ProfileTargetSlice(await this.BiRadsAssessmentCategory(), 1, "1", false),
                new ProfileTargetSlice(await this.FindingMammo(), 0, "*", false),
                new ProfileTargetSlice(await this.FindingMri(), 0, "*", false),
                new ProfileTargetSlice(await this.FindingNM(), 0, "*", false),
                new ProfileTargetSlice(await this.FindingUltraSound(), 0, "*", false)
            };
        }
    }
}
