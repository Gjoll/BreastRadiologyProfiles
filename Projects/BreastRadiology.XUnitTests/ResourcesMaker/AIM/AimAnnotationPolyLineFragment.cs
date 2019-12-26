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
        String AimAnnotationPolyLineFragment()
        {
            if (this.aimAnnotationPolyLineFragment == null)
                this.CreateAimAnnotationPolyLineFragment();
            return this.aimAnnotationPolyLineFragment;
        }
        String aimAnnotationPolyLineFragment = null;


        /// <summary>
        /// Create BreastBodyLocationFragment.
        /// </summary>
        /// <returns></returns>
        void CreateAimAnnotationPolyLineFragment()
        {
                SDefEditor e = this.CreateFragment("AimAnnotationPolyLineFragment",
                        "Aim Annotation PolyLine Fragment",
                        "Annotation/PolyLine/Fragment",
                        ObservationUrl,
                        out this.aimAnnotationPolyLineFragment)
                    .Description("Fragment definition to include AIM Annotation extension",
                        new Markdown()
                        .Paragraph("This fragment adds the references for the AIM Annotation PolyLine extension.")
                        .Todo(
                        )
                     )
                    .AddFragRef(this.HeaderFragment())
                    .AddExtensionLink(this.AimAnnotationPolyLineExtension())
                ;
                e
                    .ApplyExtension("polyLineAnnotation", this.AimAnnotationPolyLineExtension(), true, false)
                    .Single()
                    ;
                e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .Fragment($"Resource fragment that includes the Annotation PolyGonLine extension.");
        }
    }
}
