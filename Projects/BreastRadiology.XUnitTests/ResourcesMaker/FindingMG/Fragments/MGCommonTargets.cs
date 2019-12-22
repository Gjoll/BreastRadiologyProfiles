using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;
namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        async StringTask MGCommonTargetsFragment()
        {
            if (this.mgCommonTargetsFragment == null)
                await this.CreateMGCommonTargetsFragment();
            return this.mgCommonTargetsFragment;
        }
        String mgCommonTargetsFragment = null;

        async VTask CreateMGCommonTargetsFragment()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateFragment("MgCommonTargetsFragment",
                        "Mg Common Targets Fragment",
                        "Mg Common Targets Fragment",
                        ObservationUrl,
                        out this.mgCommonTargetsFragment)
                    .Description("Mammography Common Targets Fragment",
                        new Markdown()
                            .Paragraph("Mammography Common Targets Fragment")
                            .Todo(
                            )
                    )
                    .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                    ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(await this.BiRadsAssessmentCategory(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonObservedChanges(), 0, "*"),
                    new ProfileTargetSlice(await this.CommonObservedSize(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonOrientation(), 0, "1"),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }
            });
        }
    }
}
