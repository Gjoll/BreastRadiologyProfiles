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
using PreFhir;
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        async StringTask MGAbnormalityForeignObject()
        {
            if (this.mgAbnormalityForeignObject == null)
                await this.CreateMGAbnormalityForeignObject();
            return this.mgAbnormalityForeignObject;
        }
        String mgAbnormalityForeignObject = null;

        VSTaskVar MGAbnormalityForeignObjectVS = new VSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateValueSetXX(
                        "MGAbnormalities",
                        "Foreign Object",
                        "Foreign/Object/ValueSet",
                        "Foreign object codes defining types of foreign objects observed during a Breast Radiology exam",
                        Group_MGCodes,
                        await ResourcesMaker.Self.CommonAbnormalityForeignObjectCS.Value())
            );


        async VTask CreateMGAbnormalityForeignObject()
        {
            await VTask.Run((Func<VTask>)(async () =>
            {
                ValueSet binding  = await MGAbnormalityForeignObjectVS.Value();
                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    this.fc?.Mark(outputPath);
                }

                SDefEditor e = this.CreateEditor("MGAbnormalityForeignObject",
                        "Foreign Object Abnormality",
                        "Foreign Object Abnormality",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityForeign",
                        out this.mgAbnormalityForeignObject)
                    .Description("Breast Radiology Foreign Object Abnormality Observation",
                        new Markdown()
                            .Paragraph("These are foreign objects found during a breast radiology exam:")
                            .Todo(
                                "there is no way to say that the following abnormalities do not exist, only that one does exist.",
                                "fill in code descriptions",
                                "How are metal and metallic codes different",
                                "body jewelery codes",
                                "are wire and wire fragment codes the same."
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationCodedValueFragment())
                    .AddFragRef(await this.ObservationSectionFragment())
                    .AddFragRef(await this.MGCommonTargetsFragment())
                    ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(await this.BiRadsAssessmentCategory(), 0, "1"),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .CodedObservationLeafNode("a foreign object abnormality", binding)
                    ;
            }));
        }
    }
}
