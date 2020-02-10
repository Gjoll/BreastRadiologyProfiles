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
        SDTaskVar MGFinding = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateEditor("MGFinding",
                        "Mammography Finding",
                        "MG Finding",
                        Global.ObservationUrl,
                        $"{Group_MGResources}",
                        "ObservationSection")
                    .Description("Mammography Finding",
                        new Markdown()
                             .Paragraph("This resource is the Section Head for all Mammography findings.")
                             .Paragraph("All mammography observation findings are referenced by this resoruces Observation.hasMember field.")
                    )
                    .AddFragRef(Self.ObservationSectionFragment.Value())
                    ;
                s = e.SDef;
                e.Select("code").Pattern(Self.ObservationCodeMGFinding.ToCodeableConcept().ToPattern());

                ////$ todo. Incorrect method!!!
                //e.Find("method")
                // .FixedCodeSlice("method", Snomed, "115341008")
                // .Card(1, "*")
                // ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference( sliceElementDef, Self.AbnormalityCyst.Value());
                e.SliceTargetReference( sliceElementDef, Self.AbnormalityDuct.Value());
                e.SliceTargetReference( sliceElementDef, Self.AbnormalityForeignObject.Value());
                e.SliceTargetReference( sliceElementDef, Self.AbnormalityLymphNode.Value());
                e.SliceTargetReference( sliceElementDef, Self.AbnormalityMass.Value());
                e.SliceTargetReference( sliceElementDef, Self.AssociatedFeatures.Value());
                e.SliceTargetReference( sliceElementDef, Self.AbnormalityFibroadenoma.Value());
                e.SliceTargetReference( sliceElementDef, Self.MGAbnormalityArchitecturalDistortion.Value());
                e.SliceTargetReference( sliceElementDef, Self.MGAbnormalityAsymmetry.Value());
                e.SliceTargetReference( sliceElementDef, Self.MGAbnormalityCalcification.Value());
                e.SliceTargetReference( sliceElementDef, Self.MGAbnormalityDensity.Value());
                e.SliceTargetReference( sliceElementDef, Self.MGAbnormalityFatNecrosis.Value());
                e.SliceTargetReference( sliceElementDef, Self.MGBreastDensity.Value(), 1, "1");

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;
            });
    }
}