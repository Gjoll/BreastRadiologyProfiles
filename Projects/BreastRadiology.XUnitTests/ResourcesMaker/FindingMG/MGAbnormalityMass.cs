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
        VSTaskVar MassTypeValueSetVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                        "MassTypeValueSetVS",
                        "Mass Type ValueSet",
                        "Mass Type/ValueSet",
                        "Mass type value set.",
                        Group_MGCodesVS,
                        Self.CSMassType.Value()
                    )
            );

        StringTaskVar MGAbnormalityMass = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.MassTypeValueSetVS.Value();

                SDefEditor e = Self.CreateEditor("MGMass",
                        "Mammography Mass",
                        "MG Mass",
                        ObservationUrl,
                        $"{Group_MGResources}/MassAbnormality")
                    .Description("Breast Radiology Mammography Mass Observation",
                        new Markdown()
                            .MissingObservation("a mass abnormality")
                            .BiradHeader()
                            .BlockQuote("\"MASS\" is three dimensional and occupies space. It is seen on two different mammographic pro-")
                            .BlockQuote("jections. It has completely or partially convex-outward borders and (when radiodense) appears")
                            .BlockQuote("denser in the center than at the periphery. If a potential mass is seen only on a single projection, it")
                            .BlockQuote("should be called an \"ASYMMETRY\" until its 3-dimensionality is confirmed")
                            .BiradFooter()
                    //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(Self.ImagingStudyFragment.Value())
                    .AddFragRef(Self.MGCommonTargetsFragment.Value())
                    .AddFragRef(Self.MGShapeTargetsFragment.Value())
                    ;

                s = e.SDef.Url;

                e.IntroDoc
                    .ObservationSection("Mass")
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Refinement(binding, "Mass")
                    ;

                e.Select("value[x]").Zero();
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(Self.MGAssociatedFeatures.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.ConsistentWith.Value(), 0, "*"),
                };
                e.SliceByUrl("hasMember", targets);
                e.AddProfileTargets(targets);

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("mgAbnormalityMassType",
                    Self.MGCodeAbnormalityMassType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "MG AbnormalityMass Type");
                Self.ComponentSliceObservedCount(e);
            });
    }
}
