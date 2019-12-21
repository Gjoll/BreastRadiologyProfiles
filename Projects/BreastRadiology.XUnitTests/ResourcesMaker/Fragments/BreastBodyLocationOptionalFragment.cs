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
        async StringTask BreastBodyLocationOptionalFragment()
        {
            if (this.breastBodyLocationOptionalFragment == null)
                await this.CreateBreastBodyLocationOptionalFragment();
            return this.breastBodyLocationOptionalFragment;
        }
        String breastBodyLocationOptionalFragment = null;

        /// <summary>
        /// Create BreastBodyLocationFragment.
        /// </summary>
        /// <returns></returns>
        async VTask CreateBreastBodyLocationOptionalFragment()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateFragment("BreastBodyLocationOptionalFragment",
                                    "Breast Body Location (Optional) Fragment",
                                    "Breast/Body/Location/Fragment/(Optional)",
                                    ObservationUrl,
                                    out this.breastBodyLocationOptionalFragment)
                    .Description("Fragment definition for a Optional Breast Body Location",
                        new Markdown()
                        .Paragraph("This fragment adds the references for the breast body location extension.")
                        .Paragraph("The references are optional, meaning that the breast body location may exist.")
                        .Todo(
                        )
                     )
                    .AddFragRef(await this.HeaderFragment())
                    .AddExtensionLink(await this.BreastBodyLocationExtension())
                    ;
                e
                    .Select("bodySite")
                    .ZeroToOne()
                    ;
                e
                    .ApplyExtension("breastBodyLocation", await this.BreastBodyLocationExtension(), true, false)
                    .ZeroToOne()
                    ;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used by various observations to include an optional breast body location.")
                    ;
            });
        }
    }
}
