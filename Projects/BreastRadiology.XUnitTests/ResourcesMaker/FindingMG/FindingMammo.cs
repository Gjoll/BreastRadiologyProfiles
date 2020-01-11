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
                SDefEditor e = Self.CreateEditorObservationSection("MGFinding",
                        "Mammography Finding",
                        "MG Finding",
                        $"{Group_MGResources}")
                    .Description("Breast Radiology Mammography Finding",
                        new Markdown()
                        )
                    ;
                s = e.SDef;
                e.Select("value[x]").Zero();
                ////$ todo. Incorrect method!!!
                //e.Find("method")
                // .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
                // .Card(1, "*")
                // ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                Self.SliceTargetReference(e, sliceElementDef, Self.AbnormalityForeignObject.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.AssociatedFeatures.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityArchitecturalDistortion.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityAsymmetry.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityCalcification.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityCyst.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityDensity.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityDuct.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityFatNecrosis.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityFibroadenoma.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityLymphNode.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityMass.Value());
                Self.SliceTargetReference(e, sliceElementDef, Self.MGBreastDensity.Value(), 1, "1");
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
            });
    }
}