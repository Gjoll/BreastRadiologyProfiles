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
using PreFhir;
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;
namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        async StringTask BreastRadiologyPatientRiskExtension()
        {
            if (this.breastRadiologyPatientRiskExtension == null)
                await this.CreateBreastRadiologyPatientRiskExtension();
            return this.breastRadiologyPatientRiskExtension;
        }
        String breastRadiologyPatientRiskExtension = null;

        async VTask CreateBreastRadiologyPatientRiskExtension()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadPatientRiskExtension",
                    "PatientRisk Extension",
                    "PatientRisk/Extension",
                    ExtensionUrl,
                     $"{Group_ExtensionResources}/PatientRisk",
                   out this.breastRadiologyPatientRiskExtension)
                    .Description("Patient Risk section extension",
                    new Markdown()
                        .Paragraph("This extension defines the PatientRisk section of a breast radiology report, " +
                                    "linking a report to the resources that are its PatientRisk.")
                        .Todo(
                            "Do we need a BreastRadiologyPatientRisk (Tyrer Cuzack, etc) Profile"
                        )
                    )
                    .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                    .Context()
                    ;
                e.AddFragRef(await this.HeaderFragment());

                e.Select("extension").Zero();
                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url));

                e.Select("value[x]")
                    .TypeReference(MedicationRequestUrl, ServiceRequestUrl)
                    .Single()
                    ;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Extension("PatientRisk", "include references to PatientRisk")
                    ;
                e.AddLink("target", RiskAssessmentUrl, false);
                return e.SDef.Url;
            });
        }
    }
}
