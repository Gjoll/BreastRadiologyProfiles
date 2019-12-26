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
        String MGShapeTargetsFragment()
        {
            if (this.mgShapeTargetsFragment == null)
                this.CreateMGShapeTargetsFragment();
            return this.mgShapeTargetsFragment;
        }
        String mgShapeTargetsFragment = null;

        void CreateMGShapeTargetsFragment()
        {
            SDefEditor e = this.CreateFragment("MgShapeTargetsFragment",
                    "Mg Shape Targets Fragment",
                    "Mg Shape Targets Fragment",
                    ObservationUrl)
                .Description("Mammography Shape Targets Fragment",
                    new Markdown()
                        .Paragraph("Shape Common Targets Fragment")
                        .Paragraph("Adds Orientation, Shape, Margin, Density and Thickening targets")
                        .Todo(
                        )
                )
                .AddFragRef(this.BreastBodyLocationRequiredFragment())
                ;
            this.mgShapeTargetsFragment = e.SDef.Url;

            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(this.CommonOrientation(), 0, "*"),
                    new ProfileTargetSlice(this.MGShape(), 0, "1"),
                    new ProfileTargetSlice(this.MGMassMargin(), 0, "1"),
                    new ProfileTargetSlice(this.MGDensity(), 0, "1"),
                };
                e.Find("hasMember").SliceByUrl(targets);
                e.AddProfileTargets(targets);
            }
        }
    }
}
