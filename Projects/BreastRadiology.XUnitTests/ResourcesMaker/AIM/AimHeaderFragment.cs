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
        StringTaskVar AimHeaderFragment = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateFragment("AimHeaderFragment",
                    "Resource",
                    "Common/Header",
                    ResourceUrl);
                ContactDetail cd = new ContactDetail();
                cd.Telecom.Add(new ContactPoint
                {
                    System = ContactPoint.ContactPointSystem.Url,
                    Value = contactUrl
                });

                s  = e.SDef.Url;

                e.IntroDoc
                    .IntroFragment($"Resource fragment used to by all resources to define common values such as Contact and Date.")
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.SDef.Contact.Add(cd);
                e.SDef.Date = Self.date.ToString();
                e.SDef.Status = ProfileStatus;
                e.SDef.Publisher = "Hl7-Clinical Interoperability Council";
                e.SDef.Version = ProfileVersion;
            });
    }
}
