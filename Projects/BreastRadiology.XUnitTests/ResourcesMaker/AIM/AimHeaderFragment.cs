using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        public String AimHeaderFragment()
        {
            if (this.aimHeaderFragment == null)
                this.CreateAimHeaderFragment();
            return this.aimHeaderFragment;
        }
        String aimHeaderFragment = null;

        void CreateAimHeaderFragment()
        {
            SDefEditor e = this.CreateFragment("AimHeaderFragment",
                "Resource",
                "Common/Header",
                ResourceUrl);
            ContactDetail cd = new ContactDetail();
            cd.Telecom.Add(new ContactPoint
            {
                System = ContactPoint.ContactPointSystem.Url,
                Value = contactUrl
            });

            this.aimHeaderFragment = e.SDef.Url;
            e.SDef.Contact.Add(cd);
            e.SDef.Date = this.date.ToString();
            e.SDef.Status = ProfileStatus;
            e.SDef.Publisher = "Hl7-Clinical Interoperability Council";
            e.SDef.Version = ProfileVersion;

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .Fragment($"Resource fragment used to by all resources to define common values such as Contact and Date.")
                ;
        }
    }
}
