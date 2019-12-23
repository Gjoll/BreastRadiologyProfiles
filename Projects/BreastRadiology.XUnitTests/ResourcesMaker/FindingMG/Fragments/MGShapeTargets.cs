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
        async StringTask MGShapeTargetsFragment()
        {
            if (this.mgShapeTargetsFragment == null)
                await this.CreateMGShapeTargetsFragment();
            return this.mgShapeTargetsFragment;
        }
        String mgShapeTargetsFragment = null;

        async VTask CreateMGShapeTargetsFragment()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateFragment("MgShapeTargetsFragment",
                        "Mg Shape Targets Fragment",
                        "Mg Shape Targets Fragment",
                        ObservationUrl,
                        out this.mgShapeTargetsFragment)
                    .Description("Mammography Shape Targets Fragment",
                        new Markdown()
                            .Paragraph("Shape Common Targets Fragment")
                            .Paragraph("Adds Orientation, Shape, Margin, Density and Thickening targets")
                            .Todo(
                            )
                    )
                    .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                    ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(await this.CommonOrientation(), 0, "*"),
                    new ProfileTargetSlice(await this.MGShape(), 0, "1"),
                    new ProfileTargetSlice(await this.MGMassMargin(), 0, "1"),
                    new ProfileTargetSlice(await this.MGDensity(), 0, "1"),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }
            });
        }
    }
}
