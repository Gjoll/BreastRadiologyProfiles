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
        async StringTask BreastBodyLocationRequiredFragment()
        {
            if (this.breastBodyLocationRequiredFragment == null)
                await this.CreateBreastBodyLocationRequiredFragment();
            return this.breastBodyLocationRequiredFragment;
        }
        String breastBodyLocationRequiredFragment = null;


        /// <summary>
        /// Create BreastBodyLocationFragment.
        /// </summary>
        /// <returns></returns>
        async VTask CreateBreastBodyLocationRequiredFragment()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateFragment("BreastBodyLocationRequiredFragment",
                        "Breast Body Location (Required) Fragment",
                        "Breast/Body/Location/Fragment/(Required)",
                        ObservationUrl,
                        out this.breastBodyLocationRequiredFragment)
                    .Description("Fragment definition for a Required Breast Body Location",
                        new Markdown()
                        .Paragraph("This fragment adds the references for the breast body location extension.")
                        .Paragraph("The references are required, meaning that the breast body location must exist.")
                        .Todo(
                        )
                     )
                    .AddFragRef(await this.HeaderFragment())
                    .AddExtensionLink(await this.BreastBodyLocationExtension())
                ;
                e
                    .Select("bodySite")
                    .Single()
                    ;
                e
                    .ApplyExtension("breastBodyLocation", await this.BreastBodyLocationExtension(), true, false)
                    .Single()
                    ;
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used by various observations to include an required breast body location.")
                    ;
            });
        }
    }
}
