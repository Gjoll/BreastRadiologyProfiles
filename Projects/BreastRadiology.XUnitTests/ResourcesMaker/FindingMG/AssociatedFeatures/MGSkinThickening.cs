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
        async StringTask MGSkinThickening()
        {
            if (this.mgSkinThickening == null)
                await this.CreateMGSkinThickening();
            return this.mgSkinThickening;
        }
        String mgSkinThickening = null;

        async VTask CreateMGSkinThickening()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadMammoSkinThickening",
                    "Mammo Skin Thickening",
                    "Mammo/Skin/Thickening",
                    ObservationUrl,
                    $"{Group_MGResources}/AssociatedFeature/SkinThickening",
                    out this.mgSkinThickening)
                    .Description("Mammography Skin Thickening Observation",
                        new Markdown()
                            .BiradHeader()
                            .BlockQuote("Skin thickening may be focal or diffuse, and is defined as being greater than 2 mm in thickness. This ")
                            .BlockQuote("finding is of particular concern if it represents a change from previous mammography examinations. ").BlockQuote("However, unilateral skin thickening is an expected finding after radiation therapy.")
                            .BiradFooter()
                            .Todo(
                                "Add choice for focal or diffuse (see definition)?",
                                "Add body location?",
                                "Add size measurement?",
                                "cardinality 0..1 or 0..*?"
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                    ;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationLeafNode("Skin Thickening")
                    ;
            });
        }
    }
}
