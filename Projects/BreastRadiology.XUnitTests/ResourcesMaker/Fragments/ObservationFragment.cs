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
        public String ObservationFragment()
        {
            if (this.observationFragment == null)
                this.CreateObservationFragment();
            return this.observationFragment;
        }
        String observationFragment = null;

        /// <summary>
        /// Create FindingObservationFragment.
        /// </summary>
        /// <returns></returns>
        void CreateObservationFragment()
        {
            SDefEditor e = this.CreateFragment("BreastRadObservationFragment",
                "BreastRad Observation Fragment",
                    "Observation/Fragment",
                ObservationUrl)
                .Description("Base fragment for all BreastRad observations.",
                    new Markdown()
                        .Paragraph("Base fragment that performs common constrains used in all breast radiology observations.")
                        .Todo(
                        )
                )
                .AddFragRef(this.HeaderFragment())
                .AddFragRef(this.CategoryFragment())
            ;
            this.observationFragment = e.SDef.Url;
            e.Select("subject").Single();

            e.Select("component").Zero();
            e.Select("interpretation").Zero();
            e.Select("referenceRange").Zero();
            e.Select("basedOn").Zero();
            //e.Select("derivedFrom").Zero();
            e.Select("partOf").Zero();
            e.Select("focus").Zero();
            e.Select("specimen").Zero();
            e.Select("contained").Zero();

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .Fragment($"Resource fragment used by all BreatRad observations.")
                ;
        }
    }
}
