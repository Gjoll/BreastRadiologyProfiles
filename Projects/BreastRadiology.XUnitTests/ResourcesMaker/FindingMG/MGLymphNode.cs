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
        async StringTask MGLymphNode()
        {
            if (this.mgLymphNode == null)
                await this.CreateMGLymphNode();
            return this.mgLymphNode;
        }
        String mgLymphNode = null;

        async VTask CreateMGLymphNode()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs = await this.CreateCodeSystem(
                       "BreastRadMammoLymphNode",
                       "Mammography Lymph Node Refinement",
                        "Mg Lymph Node Refinement/CodeSystem",
                       "Codes defining types of mammography lymph node.",
                        Group_MGCodes,
                       new ConceptDef[]
                        {
                        new ConceptDef("Axillary",
                            "Axillary",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("Enlarged",
                            "Enlarged",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("FocalCortex",
                            "FocalCortex",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("UniformThickness",
                            "UniformThickness",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("Intramammory",
                            "Intramammory",
                            new Definition()
                            .CiteStart()
                            .Line("These are circumscribed masses that are reniform and have hilar fat. They are generally 1 cm or smaller")
                            .Line("in size. They may be larger than 1 cm and characterized as normal when fat replacement is pro-")
                            .Line("nounced. They frequently occur in the lateral and usually upper portions of the breast closer to the")
                            .Line("axilla, although they may occur anywhere in the breast. They usually are seen adjacent to a vein,")
                            .Line("because the lymphatic drainage of the breast parallels the venous drainage.")
                            .CiteEnd(BiRadCitation)
                            ),
                        new ConceptDef("InternalMargin",
                            "Internal Margin",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("Normal",
                            "Normal",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("PathLymphNode",
                            "Path Lymph Node",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("xxyyz",
                            "xxyyz",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("xxyyz",
                            "xxyyz",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("xxyyz",
                            "xxyyz",
                            new Definition()
                                .Line("Penrad")
                            ),
                        }
                    );

                ValueSet binding = await this.CreateValueSet(
                   "BreastRadMammoLymphNode",
                   "Mammography Lymph Node",
                    "Mg Lymph Node/ValueSet",
                   "Codes defining types of mammography lymph node.",
                    Group_MGCodes,
                    cs);

                SDefEditor e = this.CreateEditor("BreastRadMammoLymphNode",
                    "Mammography LymphNode",
                    "Mg Lymph Node",
                    ObservationUrl,
                    $"{Group_MGResources}/LymphNode",
                    out this.mgLymphNode)
                    .Description("Breast Radiology Mammography LymphNode Observation",
                        new Markdown()
                            .MissingObservation("a lymph node")
                            .Todo(
                                "should this be a leaf node (how about shape, density, location, etc)."
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                    .AddFragRef(await this.ObservationCodedValueFragment())
                    .AddFragRef(await this.ObservationLeafFragment())
                    ;

                e.Select("value[x]")
                    .ZeroToOne()
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);

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

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Lymph Node")
                    .Refinement(binding, "LymphNode")
                    ;
            });
        }
    }
}
