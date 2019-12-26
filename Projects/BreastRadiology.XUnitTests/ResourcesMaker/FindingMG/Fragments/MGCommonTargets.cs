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

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        String MGCommonTargetsFragment()
        {
            if (this.mgCommonTargetsFragment == null)
                this.CreateMGCommonTargetsFragment();
            return this.mgCommonTargetsFragment;
        }
        String mgCommonTargetsFragment = null;

        void CreateMGCommonTargetsFragment()
        {
            SDefEditor e = this.CreateFragment("MgCommonTargetsFragment",
                    "Mg Common Targets Fragment",
                    "Mg Common Targets Fragment",
                    ObservationUrl)
                .Description("Mammography Common Targets Fragment",
                    new Markdown()
                        .Paragraph("Mammography Common Targets Fragment")
                        .Todo(
                        )
                )
                .AddFragRef(this.BreastBodyLocationRequiredFragment())
                ;
            this.mgCommonTargetsFragment = e.SDef.Url;

            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(this.BiRadsAssessmentCategory(), 0, "1"),
                    new ProfileTargetSlice(this.CommonObservedChangeInDefinition(), 0, "1"),
                    new ProfileTargetSlice(this.CommonObservedChangeInNumber(), 0, "1"),
                    new ProfileTargetSlice(this.CommonObservedChangeInProminance(), 0, "1"),
                    new ProfileTargetSlice(this.CommonObservedChangeInSize(), 0, "1"),
                    new ProfileTargetSlice(this.CommonObservedChangeInState(), 0, "1"),
                    new ProfileTargetSlice(this.CommonObservedSize(), 0, "1"),
                    new ProfileTargetSlice(this.CommonOrientation(), 0, "1"),
                };
                e.Find("hasMember").SliceByUrl(targets);
                e.AddProfileTargets(targets);
            }
        }
    }
}
