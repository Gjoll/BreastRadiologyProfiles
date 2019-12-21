using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using PreFhir;
using System;
using System.Collections.Generic;
using System.Text;
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;
namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        public async StringTask ImagingStudyFragment()
        {
            if (this.aimImagingStudyFragment == null)
                await this.CreateImagingStudyFragment();
            return this.aimImagingStudyFragment;
        }
        String aimImagingStudyFragment = null;


        async VTask CreateImagingStudyFragment()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateFragment("ImagingStudyFragment",
                        "Imaging Study Fragment",
                        "ImagingStudy",
                        ObservationUrl,
                        out this.aimImagingStudyFragment)
                    .Description("Adds references to imaging studies.",
                        new Markdown()
                            .Paragraph("Fragment that adds derivedFrom references to imaging studies, including AIM annotated imaaging study.")
                            .Todo(
                            )
                     )
                    ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(ImagingStudyUrl, 0, "*"),
                    new ProfileTargetSlice(await this.AimAnnotatedImagingStudy(), 0, "1"),
                    };
                    e.Find("derivedFrom").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Imaging Study Fragment")
                    ;
            });
        }
    }
}
