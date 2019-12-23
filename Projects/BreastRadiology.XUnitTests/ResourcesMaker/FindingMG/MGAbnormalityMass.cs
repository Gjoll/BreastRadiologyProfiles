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
        async StringTask MGAbnormalityMass()
        {
            if (this.mgAbnormalityMass == null)
                await this.CreateMGAbnormalityMass();
            return this.mgAbnormalityMass;
        }
        String mgAbnormalityMass = null;


        VSTaskVar MassRefinementValueSetVS = new VSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateValueSetXX(
                        "MassRefinementValueSet",
                        "Mass Refinement ValueSet",
                        "Mass Refinement/ValueSet",
                        "Codes refining mass type.",
                        Group_MGCodes,
                        await ResourcesMaker.Self.CommonCSMassRefinement.Value()
                    )
            );

        async VTask CreateMGAbnormalityMass()
        {
            await VTask.Run(async () =>
            {
                ValueSet binding = await this.MassRefinementValueSetVS.Value();

                SDefEditor e = this.CreateEditor("BreastRadMammoMass",
                        "Mammography Mass Abnormality",
                        "Mg Mass Abnormality",
                        ObservationUrl,
                        $"{Group_MGResources}/MassAbnormality",
                        out this.mgAbnormalityMass)
                    .Description("Breast Radiology Mammography Mass Abnormality Observation",
                        new Markdown()
                            .MissingObservation("a mass abnormality")
                            .BiradHeader()
                            .BlockQuote("\"MASS\" is three dimensional and occupies space. It is seen on two different mammographic pro-")
                            .BlockQuote("jections. It has completely or partially convex-outward borders and (when radiodense) appears")
                            .BlockQuote("denser in the center than at the periphery. If a potential mass is seen only on a single projection, it")
                            .BlockQuote("should be called an \"ASYMMETRY\" until its 3-dimensionality is confirmed")
                            .BiradFooter()
                            .Todo(
                                "add mass size measurements (3 dimensional) like US?",
                                "same for asymmetry, lesion, calcification?"
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationCodedValueFragment())
                    .AddFragRef(await this.ObservationSectionFragment())
                    .AddFragRef(await this.ImagingStudyFragment())
                    .AddFragRef(await this.MGCommonTargetsFragment())
                    .AddFragRef(await this.MGShapeTargetsFragment())
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
                    new ProfileTargetSlice(await this.CommonObservedCount(), 0, "1"),
                    new ProfileTargetSlice(await this.MGAssociatedFeatures(), 0, "1"),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("Mammography Mass Abnormality")
                    .Refinement(binding, "Mass")
                    ;
            });
        }
    }
}
