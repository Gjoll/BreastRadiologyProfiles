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
    partial class ResourcesMaker : ConverterBase
    {
        SDTaskVar FindingMammo = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateEditor("MGFinding",
                        "Mammography Finding",
                        "MG Finding",
                        ObservationUrl,
                        $"{Group_MGResources}",
                        "ObservationSection")
                    .Description("Breast Radiology Mammography Finding",
                        new Markdown()
                             .Paragraph("This resource is the Section Head for all Mammography findings.")
                             .Paragraph("All mammography observation findings are referenced by this resoruces Observation.hasMember field")
                    )
                    .AddFragRef(Self.ObservationSectionFragment.Value())
                    ;
                s = e.SDef;

                ////$ todo. Incorrect method!!!
                //e.Find("method")
                // .FixedCodeSlice("method", Snomed, "115341008")
                // .Card(1, "*")
                // ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                Self.SliceTargetReference(e, sliceElementDef, Self.AbnormalityCyst.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.AbnormalityDuct.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.AbnormalityForeignObject.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.AbnormalityLymphNode.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.AbnormalityMass.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.AssociatedFeatures.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.AbnormalityFibroadenoma.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityArchitecturalDistortion.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityAsymmetry.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityCalcification.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityDensity.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityFatNecrosis.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGBreastDensity.Value(), 1, "1");

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
            });
    }
}