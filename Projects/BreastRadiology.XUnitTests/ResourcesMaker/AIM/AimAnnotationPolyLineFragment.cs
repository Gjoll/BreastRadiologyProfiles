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
        StringTaskVar AimAnnotationPolyLineFragment = new StringTaskVar(
            (out String s) =>
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
                    .AddFragRef(Self.HeaderFragment.Value())
                    .AddExtensionLink(Self.AimAnnotationPolyLineExtension.Value())
                ;
                s = e.SDef.Url;
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment that includes the Annotation PolyGonLine extension.")
                    ;

                e
                    .ApplyExtension("polyLineAnnotation", Self.AimAnnotationPolyLineExtension.Value(), true, false)
                    .Single()
                    ;
            });


    }
}
