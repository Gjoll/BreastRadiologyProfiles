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
                SDefEditor e = ResourcesMaker.Self.CreateFragment("AimAnnotationPolyLineFragment",
                        "Aim Annotation PolyLine Fragment",
                        "Annotation/PolyLine/Fragment",
                        ObservationUrl)
                    .Description("Fragment definition to include AIM Annotation extension",
                        new Markdown()
                        .Paragraph("This fragment adds the references for the AIM Annotation PolyLine extension.")
                        //.Todo
                     )
                    .AddFragRef(ResourcesMaker.Self.HeaderFragment.Value())
                    .AddExtensionLink(ResourcesMaker.Self.AimAnnotationPolyLineExtension.Value())
                ;
                s = e.SDef.Url;
                e
                    .ApplyExtension("polyLineAnnotation", ResourcesMaker.Self.AimAnnotationPolyLineExtension.Value(), true, false)
                    .Single()
                    ;
                e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .Fragment($"Resource fragment that includes the Annotation PolyGonLine extension.");
            });


    }
}
