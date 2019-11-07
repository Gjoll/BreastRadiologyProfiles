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

namespace FhirKhit.BreastRadiology.XUnitTests
{
    public partial class ResourcesMaker : ConverterBase
    {
        String BreastRadiologyRecommendations()
        {
            SDefEditor e = this.CreateEditor("BreastRadRecommendations", "Recommendations", ExtensionUrl)
                .Description(new Markdown()
                    .Paragraph("Diagnostic Report recommendations section extension")
                )
                .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                .Context()
                ;

            e.Select("extension").Zero();
            e.Select("url")
                .Type("uri")
                .Fixed(new FhirUri(e.SDef.Url));

            e.Select("value[x]")
                .TypeReference(MedicationRequestUrl, ServiceRequestUrl)
                .Single()
                ;
            return e.SDef.Url;
        }
    }
}
