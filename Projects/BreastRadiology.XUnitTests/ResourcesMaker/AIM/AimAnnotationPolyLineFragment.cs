using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using PreFhir;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        SDTaskVar AimAnnotationPolyLineFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateFragment("AimAnnotationPolyLineFragment",
                        "Aim Annotation PolyLine Fragment",
                        "Annotation/PolyLine/Fragment",
                        ObservationUrl)
                    .Description("AIM Annotation PolyLine fragment",
                        new Markdown()
                        .Paragraph("This fragment adds the references for the AIM Annotation PolyLine extension.")
                     )
                    .AddFragRef(Self.HeaderFragment.Value())
                ;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
                s = e.SDef;

                e
                    .ApplyExtension("polyLineAnnotation", Self.AimAnnotationPolyLineExtension.Value(), true)
                    .Single()
                    ;
            });


    }
}
