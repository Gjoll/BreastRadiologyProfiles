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
                    .Description("Fragment definition to include AIM Annotation extension",
                        new Markdown()
                        .Paragraph("This fragment adds the references for the AIM Annotation PolyLine extension.")
                        //.Todo
                     )
                    .AddFragRef(Self.HeaderFragment.Value().Url)
                ;

                e.IntroDoc
                    .Intro($"Resource fragment that includes the Annotation PolyGonLine extension.")
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
                s = e.SDef;

                e
                    .ApplyExtension("polyLineAnnotation", Self.AimAnnotationPolyLineExtension.Value().Url, true)
                    .Single()
                    ;
            });


    }
}
