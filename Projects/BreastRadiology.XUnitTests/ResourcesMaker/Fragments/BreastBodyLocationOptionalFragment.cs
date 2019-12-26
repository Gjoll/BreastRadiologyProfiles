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
        String BreastBodyLocationOptionalFragment()
        {
            if (this.breastBodyLocationOptionalFragment == null)
                this.CreateBreastBodyLocationOptionalFragment();
            return this.breastBodyLocationOptionalFragment;
        }
        String breastBodyLocationOptionalFragment = null;

        /// <summary>
        /// Create BreastBodyLocationFragment.
        /// </summary>
        /// <returns></returns>
        void CreateBreastBodyLocationOptionalFragment()
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
                .AddFragRef(this.HeaderFragment())
                .AddExtensionLink(this.BreastBodyLocationExtension())
                ;
            e
                .Select("bodySite")
                .ZeroToOne()
                ;
            e
                .ApplyExtension("breastBodyLocation", this.BreastBodyLocationExtension(), true, false)
                .ZeroToOne()
                ;

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .Fragment($"Resource fragment used by various observations to include an optional breast body location.")
                ;
        }
    }
}
