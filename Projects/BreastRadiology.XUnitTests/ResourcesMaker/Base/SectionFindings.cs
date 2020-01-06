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
        SDTaskVar SectionFindings = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateEditorObservationSection("SectionFindings",
                        "Findings",
                        "Findings",
                        $"{Group_BaseResources}/Findings")
                    .Description("Findings Section",
                        new Markdown()
                        .Paragraph("This resource is the head of the tree of observations made during a breast radiology exam.")
                        .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value().Url)
                    ;

                s = e.SDef;
                e.IntroDoc
                     .ReviewedStatus(ReviewStatus.NotReviewed)
                     ;

                e.Select("value[x]").Zero();
                e.Select("bodySite").Zero();

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);

                Self.SliceTargetReference(e, sliceElementDef, Self.SectionFindingsLeftBreast.Value(), 1, "1");
                Self.SliceTargetReference(e, sliceElementDef, Self.SectionFindingsRightBreast.Value(), 1, "1");

                e.StartComponentSliceing();
                Self.ComponentSliceBiRads(e);
            });
    }
}
