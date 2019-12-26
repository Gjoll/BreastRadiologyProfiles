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
        String BreastBodyLocationRequiredFragment()
        {
            if (this.breastBodyLocationRequiredFragment == null)
                this.CreateBreastBodyLocationRequiredFragment();
            return this.breastBodyLocationRequiredFragment;
        }
        String breastBodyLocationRequiredFragment = null;


        /// <summary>
        /// Create BreastBodyLocationFragment.
        /// </summary>
        /// <returns></returns>
        void CreateBreastBodyLocationRequiredFragment()
        {
            SDefEditor e = this.CreateFragment("BreastBodyLocationRequiredFragment",
                    "Breast Body Location (Required) Fragment",
                    "Breast/Body/Location/Fragment/(Required)",
                    ObservationUrl)
                .Description("Fragment definition for a Required Breast Body Location",
                    new Markdown()
                    .Paragraph("This fragment adds the references for the breast body location extension.")
                    .Paragraph("The references are required, meaning that the breast body location must exist.")
                    .Todo(
                    )
                 )
                .AddFragRef(this.HeaderFragment())
                .AddExtensionLink(this.BreastBodyLocationExtension())
            ;
            this.breastBodyLocationRequiredFragment = e.SDef.Url;
            e
                .Select("bodySite")
                .Single()
                ;
            e
                .ApplyExtension("breastBodyLocation", this.BreastBodyLocationExtension(), true, false)
                .Single()
                ;
            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .Fragment($"Resource fragment used by various observations to include an required breast body location.")
                ;
        }
    }
}
