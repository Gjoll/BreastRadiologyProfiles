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
        async StringTask CommonForeignObject()
        {
            if (this.commonForeignObject == null)
                await this.CreateCommonForeignObject();
            return this.commonForeignObject;
        }
        String commonForeignObject = null;

        async VTask CreateCommonForeignObject()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs  = await this.CreateCodeSystem(
                        "CommonAbnormalities",
                        "Foreign Object",
                        "Foreign/Object/Values",
                        "Foreign object codes defining types of foreign objects observed during a Breast Radiology exam",
                        Group_CommonCodes,
                        new ConceptDef[]
                        {
                        new ConceptDef("BB",
                            "BB",
                            new Definition()
                                .Line("A foreign object is identified as a BB")
                            ),
                        new ConceptDef("BiopsyClip",
                            "Biopsy Clip",
                            new Definition()
                                .Line("A foreign object is identified as a Biopsy Clip")
                            ),
                        new ConceptDef("BiopsyClipTitanium",
                            "Biopsy Clip Titanium",
                            new Definition()
                                .Line("A foreign object is identified as a Titanium Biopsy Clip")
                            ),
                        new ConceptDef("CatheterSleeve",
                            "Catheter Sleeve",
                            new Definition()
                                .Line("A foreign object is identified as a Catheter Sleeve")
                            ),
                        new ConceptDef("ChemotherapyPort",
                            "Chemotherapy Port",
                            new Definition()
                                .Line("A foreign object is identified as a Chemotherapy Port")
                            ),
                        new ConceptDef("Coil",
                            "Coil",
                            new Definition()
                                .Line("A foreign object is identified as a Coil")
                            ),
                        new ConceptDef("GunShotWound",
                            "Gun Shot Wound",
                            new Definition()
                                .Line("A foreign object is identified as a Gun Shot Wound")
                            ),
                        new ConceptDef("Metal",
                            "Metal",
                            new Definition()
                                .Line("A foreign object is identified as a Metal")
                            ),
                        new ConceptDef("MetallicObjects",
                            "Metallic Objects",
                            new Definition()
                                .Line("A foreign object is identified as a Metallic Objects")
                            ),
                        new ConceptDef("Needle",
                            "Needle",
                            new Definition()
                                .Line("A foreign object is identified as a Needle")
                            ),
                        new ConceptDef("NippleJewelery",
                            "Nipple Jewelery",
                            new Definition()
                                .Line("A foreign object is identified as a Nipple Jewelery")
                            ),
                        new ConceptDef("NonMetallicBody",
                            "Non Metallic Body",
                            new Definition()
                                .Line("A foreign object is identified as a Non Metallic Body")
                            ),
                        new ConceptDef("PaceMaker",
                            "Pace Maker",
                            new Definition()
                                .Line("A foreign object is identified as a Pace Maker")
                            ),
                        new ConceptDef("RadioactivePellet",
                            "Radioactive Pellet",
                            new Definition()
                                .Line("A foreign object is identified as a Radioactive Pellet")
                            ),
                        new ConceptDef("Sponge",
                            "Sponge",
                            new Definition()
                                .Line("A foreign object is identified as a Sponge")
                            ),
                        new ConceptDef("SurgicalClip",
                            "Surgical Clip",
                            new Definition()
                                .Line("A foreign object is identified as a Surgical Clip")
                            ),
                        new ConceptDef("Swab",
                            "Swab",
                            new Definition()
                                .Line("A foreign object is identified as a Swab")
                            ),
                        new ConceptDef("Wire",
                            "Wire",
                            new Definition()
                                .Line("A foreign object is identified as a Wire")
                            ),
                        new ConceptDef("WireFragment",
                            "Wire Fragment",
                            new Definition()
                                .Line("A foreign object is identified as a Wire Fragment")
                            )
                        })
                    ;

                ValueSet binding  = await this.CreateValueSet(
                        "CommonAbnormalities",
                        "Foreign Object",
                        "Foreign/Object/Values",
                        "Foreign object codes defining types of foreign objects observed during a Breast Radiology exam",
                        Group_CommonCodes,
                        cs);
                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    this.fc.Mark(outputPath);
                }

                SDefEditor e = this.CreateEditor("CommonForeignObject",
                        "ForeignObject",
                        "ForeignObject",
                        ObservationUrl,
                        $"{Group_CommonResources}/Foreign",
                        out this.commonForeignObject)
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
                    .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationCodedValueFragment())
                    .AddFragRef(await this.ObservationSectionFragment())
                    ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(await this.BiRadsAssessmentCategory(), 0, "1"),

                    new ProfileTargetSlice(await this.CommonObservedCount(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonObservedChanges(), 0, "*"),
                    new ProfileTargetSlice(await this.CommonObservedSize(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonOrientation(), 0, "1"),
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
                    .CodedObservationLeafNode(e, "an ForeignObject", binding)
                    ;
            });
        }
    }
}
