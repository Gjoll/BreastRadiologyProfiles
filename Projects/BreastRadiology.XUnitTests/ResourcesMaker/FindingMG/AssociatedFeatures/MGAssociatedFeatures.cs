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
        SDTaskVar MGAssociatedFeatures = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditorObservationSection("MGAssociatedFeatures",
                        "Mammography Associated Features",
                        "MG Associated/Features",
                        $"{Group_MGResources}/AssociatedFeature")
                    .Description("Mammography Associated Features Observation",
                        new Markdown()
                            .Paragraph("Used with masses, asymmetries, or calcifications, or may stand alone as " +
                                        "Features when no other abnormality is present.")
                     )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value().Url)
                    .AddFragRef(Self.ObservationNoValueFragment.Value().Url)
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);

                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityArchitecturalDistortion.Value(), 0, "*");
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityCalcification.Value(), 0, "*");
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAxillaryAdenopathy.Value(), 0, "1");
                Self.SliceTargetReference(e, sliceElementDef, Self.MGNippleRetraction.Value(), 0, "1");
                Self.SliceTargetReference(e, sliceElementDef, Self.MGSkinRetraction.Value(), 0, "1");
                Self.SliceTargetReference(e, sliceElementDef, Self.MGSkinThickening.Value(), 0, "*");
            });
    }
}
