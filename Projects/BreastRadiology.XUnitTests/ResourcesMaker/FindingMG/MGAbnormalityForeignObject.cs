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

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        VSTaskVar MGAbnormalityForeignObjectVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                        "MGAbnormalitiesVS",
                        "Foreign Object ValueSet",
                        "Foreign/Object/ValueSet",
                        "Foreign objects observed during a Breast Radiology exam value set",
                        Group_MGCodesVS,
                        Self.AbnormalityForeignObjectCS.Value())
            );


        StringTaskVar MGAbnormalityForeignObject = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.MGAbnormalityForeignObjectVS.Value();
                {
                    IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                    valueSetIntroDoc
                        .IntroValueSet(binding)
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditorObservationSection("MGAbnormalityForeignObject",
                        "Foreign Object",
                        "Foreign Object",
                        $"{Group_MGResources}/AbnormalityForeign")
                    .Description("Breast Radiology Foreign Object Observation",
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
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(Self.MGCommonTargetsFragment.Value())
                    ;

                s = e.SDef.Url;

                //$e.IntroDoc
                //    .IntroCodedObservationLeafNode("a foreign object abnormality")
                //    .ReviewedStatus(ReviewStatus.NotReviewed)
                //    .Refinement(binding, "Foreign Object")
                //    ;

                e.Select("value[x]").Zero();
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(Self.ConsistentWith.Value(), 0, "*"),
                };
                e.SliceByUrl("hasMember", targets);
                e.AddProfileTargets(targets);

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("mgAbnormalityForeignObjectType",
                    Self.MGCodeAbnormalityForeignObjectType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "MG AbnormalityForeignObject Type");
                Self.ComponentSliceBiRads(e);
            });
    }
}
